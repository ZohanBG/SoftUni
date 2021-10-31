using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();
            string result = RemoveTown(db);

            Console.WriteLine(result);
        }

        //3.	Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in context.Employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //4.	Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new { 
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} - {item.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
                
        }

        //5.	Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    DepartamentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} from {item.DepartamentName} - ${item.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //6.	Adding a New Address and Updating Employee
        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            Address newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context.Employees.First(e => e.LastName == "Nakov");
            nakov.Address = newAdress;
            context.SaveChanges();

            Employee[] employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToArray();

            foreach (var item in employees)
            {
                sb.AppendLine(item.Address.AddressText);
            }

            return sb.ToString().TrimEnd();
                
        }

        //7.	Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
           .Where(p => p.EmployeesProjects
           .Any(d => d.Project.StartDate.Year >= 2001 && d.Project.StartDate.Year <= 2003))
           .Select(
            e => new
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Manager = e.Manager,
                EmployeesProjects = e.EmployeesProjects
                .Select(p => new
                {
                    ProjectName = p.Project.Name,
                    StartDate = p.Project.StartDate,
                    EndDate = p.Project.EndDate
                }).ToList()

            }
            ).ToList();

            foreach (var e in employees.Take(10))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");

                foreach (var project in e.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.ProjectName} -" +
                                       $" {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - " +
                                       $"{(project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }
            }
            return sb.ToString().TrimEnd();

        }

        //8.	Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var adresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToArray();
            foreach (var item in adresses)
            {
                sb.AppendLine($"{item.AddressText}, {item.TownName} - {item.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        
        }

        //9.	Employee 147
        public static string GetEmployee147(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new 
                { 
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    EmployeeProjects = e.EmployeesProjects
                    .OrderBy(d=> d.Project.Name)
                    .Select(d => new 
                    { 
                        d.Project.Name
                    })
                    .ToArray()
                });


            foreach (var item in employee)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle}");

                foreach (var project in item.EmployeeProjects)
                {
                    sb.AppendLine(project.Name);
                }
            }

            return sb.ToString().TrimEnd();
        
        }

        //10.	Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d=> d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new 
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    employees = d.Employees
                    .Select(e => new 
                    { 
                        e.FirstName,
                        e.LastName,
                        e.JobTitle           
                    })
                    .ToArray()
                
                })
                .ToArray();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName}  {department.ManagerLastName}");

                foreach (var employee in department.employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        
        }

        //11.	Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            Project[] projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var item in projects)
            {
                sb.AppendLine(item.Name);
                sb.AppendLine(item.Description);
                sb.AppendLine(item.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return sb.ToString().TrimEnd();
     
        }

        //12.	Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                || e.Department.Name == "Tool Design"
                || e.Department.Name == "Marketing"
                || e.Department.Name == "Information Services");

            foreach (var e in employees)
            {
                e.Salary += e.Salary * 0.12m;
            }

            context.SaveChanges();

            var displayedEmployees = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in displayedEmployees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        
        }

        //13.	Find Employees by First Name Starting with "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employee = context.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var item in employee)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            }

            return sb.ToString().TrimEnd();

        }

        //14.	Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            Project project = context.Projects.Find(2);

            var epCol = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();
            foreach (var item in epCol)
            {
                context.Remove(item);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            Project[] projects = context.Projects.Take(10).ToArray();

            foreach (var item in projects)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().TrimEnd();
        
        }

        //15.	Remove Town
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns
                .First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete =
                context
                    .Addresses
                    .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            IQueryable<Employee> employeesOnDeletedAddresses =
                context
                    .Employees
                    .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesOnDeletedAddresses)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";

        }


    }
}
