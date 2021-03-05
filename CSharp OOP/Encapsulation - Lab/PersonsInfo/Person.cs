using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName 
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
                this.firstName = value;
            }
        }
        public string LastName 
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }

        public int Age 
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary 
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value;
            }
        }

        public Person IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary +=Salary * percentage / 200;
            }
            else
            {
                Salary +=Salary * percentage/100;
            }
            return this;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}
