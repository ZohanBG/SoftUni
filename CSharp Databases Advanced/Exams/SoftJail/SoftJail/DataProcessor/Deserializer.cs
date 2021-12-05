namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentCellDto[] departmentCellDtos = JsonConvert.DeserializeObject<ImportDepartmentCellDto[]>(jsonString);

            List<Department> departments = new List<Department>();


            foreach (var departmentCellDto in departmentCellDtos)
            {
                bool hasInvalidCell = false;

                if (!IsValid(departmentCellDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentCellDto.Name
                };

                List<Cell> cells = new List<Cell>();

                foreach (var cellDto in departmentCellDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        hasInvalidCell = true;
                        sb.AppendLine("Invalid Data");
                        break;
                    }

                    cells.Add(new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (!hasInvalidCell)
                {
                    department.Cells = cells;
                    departments.Add(department);
                    sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrissonerMailDto[] prisonerMailDtos = JsonConvert.DeserializeObject<ImportPrissonerMailDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (var prisonerMailDto in prisonerMailDtos)
            {
                bool hasInvalidMail = false;

                if (!IsValid(prisonerMailDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerMailDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate = null;

                if (!String.IsNullOrWhiteSpace(prisonerMailDto.ReleaseDate))
                {
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerMailDto.ReleaseDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newReleaseDate);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    releaseDate = newReleaseDate;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerMailDto.FullName,
                    Nickname = prisonerMailDto.Nickname,
                    Age = prisonerMailDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerMailDto.Bail,
                    CellId = prisonerMailDto.CellId
                };

                List<Mail> mails = new List<Mail>();

                foreach (var mail in prisonerMailDto.Mails)
                {
                    if (!IsValid(mail))
                    {
                        hasInvalidMail = true;
                        sb.AppendLine("Invalid Data");
                        break;
                    }

                    mails.Add(new Mail()
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    });
                }

                if (!hasInvalidMail)
                {
                    prisoner.Mails = mails;
                    prisoners.Add(prisoner);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Officers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerPrisonerDto[]), xmlRoot);

            ImportOfficerPrisonerDto[] officerPrisonerDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                officerPrisonerDtos = (ImportOfficerPrisonerDto[])xmlSerializer.Deserialize(sr);
            }

            StringBuilder sb = new StringBuilder();

            List<Officer> officers = new List<Officer>();

            foreach (var officerPrisonerDto in officerPrisonerDtos)
            {
                if (!IsValid(officerPrisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object positionObj;
                bool isPositionValid = Enum.TryParse(typeof(Position), officerPrisonerDto.Position, out positionObj);

                if (!isPositionValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object weaponObj;
                bool isWeaponValid = Enum.TryParse(typeof(Weapon), officerPrisonerDto.Weapon, out weaponObj);

                if (!isWeaponValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerPrisonerDto.Name,
                    Salary = officerPrisonerDto.Money,
                    Position = (Position)positionObj,
                    Weapon = (Weapon)weaponObj,
                    DepartmentId = officerPrisonerDto.DepartmentId
                };


                foreach (var prisoner in officerPrisonerDto.Prisoners)
                {
                    officer.OfficerPrisoners.Add(new OfficerPrisoner() { PrisonerId = prisoner.Id });
                }

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}