namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .ToArray()
                .Where(p => ids.Any(i => i == p.Id))
                .Select(p => new
                {
                    p.Id,
                    Name = p.FullName,
                    p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(o => new
                    {
                        OfficerName = o.Officer.FullName,
                        Department = o.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary =Math.Round(p.PrisonerOfficers.Sum(o => o.Officer.Salary),2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(prisoners, Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] names = prisonersNames.Split(",");

            ExportPrisonerWithMessagesDto[] prisoners = context.Prisoners
                .Where(p => names.Any(n => n == p.FullName))
                .Select(p => new ExportPrisonerWithMessagesDto()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                    .Select(m => new MessageDto() {
                        Description = new string(m.Description.ToCharArray().Reverse().ToArray())
                    })
                    .ToArray()

                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();


            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Prisoners");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerWithMessagesDto[]), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, prisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}