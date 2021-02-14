using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            employees = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return employees.Count;} }

        public void Add(Employee employee)
        {
            if (employees.Count < Capacity)
            {
                employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = employees.FirstOrDefault(n => n.Name == name);
            if (employee == null)
            {
                return false;
            }
            employees.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            return employees.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return employees.FirstOrDefault(n => n.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in employees)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString();
        }
    }
}
