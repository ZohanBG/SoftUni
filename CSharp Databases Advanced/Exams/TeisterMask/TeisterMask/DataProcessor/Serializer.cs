namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            ExportProjectWithTasksDto[] projects = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Count >= 1)
                .Select(p => new ExportProjectWithTasksDto()
                {
                    TasksCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                    .Select(t => new ExportTaskDto
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                    .OrderBy(t => t.Name)
                    .ToArray()
                })
                .OrderByDescending(p => p.Tasks.Length)
                .ThenBy(p => p.ProjectName)
                .ToArray();

            XmlRootAttribute xmlRootAttribute = new XmlRootAttribute("Projects");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectWithTasksDto[]), xmlRootAttribute);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            StringBuilder sb = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, projects, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context.Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(e => new
                {
                    e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(t => t.Task.OpenDate >= date)
                    .Select(t => t.Task)
                    .OrderByDescending(t => t.DueDate)
                    .ThenBy(t => t.Name)
                    .Select(t => new
                    {
                        TaskName = t.Name,
                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.LabelType.ToString(),
                        ExecutionType = t.ExecutionType.ToString()
                    })
                    .ToArray()


                })
                .OrderByDescending(e => e.Tasks.Length)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(busiestEmployees, Formatting.Indented);
        }
    }
}
