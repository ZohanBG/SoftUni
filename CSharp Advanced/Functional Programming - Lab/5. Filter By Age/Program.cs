using System;

namespace _5._Filter_By_Age
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(", ");
                people[i] = new Person();
                people[i].Name = info[0];
                people[i].Age = int.Parse(info[1]);
            }

            string filter = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Person, bool> condition = Filter(filter, age);

            string formatType = Console.ReadLine();
            Func<Person, string> formatter = GetFormatter(formatType);

            Printer(people,condition,formatter);
        }
        static Func<Person,string> GetFormatter(string formatType)
        {
            switch (formatType)
            {
                case "name":
                    return p=>$"{p.Name}";
                case "age":
                    return p => $"{p.Age}";
                case "name age":
                    return p => $"{p.Name} - {p.Age}";
                default:
                    return null;

            }

        }
        // Age filtering
        static Func<Person,bool> Filter(string filter,int age)
        {
            switch (filter)
            {
                case "younger":
                    return n=>n.Age<age;
                case "older":
                    return n => n.Age >= age;
                default:
                    return null;
            }
        } 
        //Printing
        static void Printer(Person[] people, Func<Person, bool> condition, Func<Person, string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));
                }
            }
        }
    }
}
