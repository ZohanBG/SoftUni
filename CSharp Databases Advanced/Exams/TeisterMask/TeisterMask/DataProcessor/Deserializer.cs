namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectTask[]), xmlRoot);

            ImportProjectTask[] projectDtos;

            using (StringReader sr = new StringReader(xmlString))
            {
                projectDtos = (ImportProjectTask[])xmlSerializer.Deserialize(sr);
            }

            StringBuilder sb = new StringBuilder();

            HashSet<Project> projects = new HashSet<Project>();
            foreach (ImportProjectTask projectDto in projectDtos)
            {
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None
                    , out DateTime openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!String.IsNullOrWhiteSpace(projectDto.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None
                    , out DateTime dueDateValue);

                    if(!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                Project p = new Project() 
                { 
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                HashSet<Task> projectTasks = new HashSet<Task>();

                foreach (ImportTaskDto projectTask in projectDto.Tasks)
                {
                    if (!IsValid(projectTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isOpenTaskDateValid = DateTime.TryParseExact(projectTask.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None
                    , out DateTime openTaskDate);

                    if (!isOpenTaskDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueTaskDateValid = DateTime.TryParseExact(projectTask.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None
                    , out DateTime dueTaskDate);

                    if (!isDueTaskDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(openTaskDate < p.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(p.DueDate.HasValue && dueTaskDate > p.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task t = new Task()
                    {
                        Name = projectTask.Name,
                        OpenDate = openTaskDate,
                        DueDate = dueTaskDate,
                        ExecutionType = (ExecutionType)projectTask.ExecutionType,
                        LabelType = (LabelType)projectTask.LabelType
                    };

                    projectTasks.Add(t);
                }

                p.Tasks= projectTasks;
                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, projectTasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            HashSet<Employee> employees = new HashSet<Employee>();

            foreach (ImportEmployeeDto employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                HashSet<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();

                foreach (int TaskId in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.Find(TaskId);

                    if(task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = e,
                        TaskId = TaskId
                    };
                    employeeTasks.Add(employeeTask);
                }

                e.EmployeesTasks = employeeTasks;
                employees.Add(e);

                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, employeeTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}