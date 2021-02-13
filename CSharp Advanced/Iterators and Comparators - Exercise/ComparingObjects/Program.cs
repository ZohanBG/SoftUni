using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> people = new List<Person>();
            while(input!= "END")
            {
                string[] inputData = input.Split();
                Person person = new Person(inputData[0], int.Parse(inputData[1]), inputData[2]);
                people.Add(person);
                input = Console.ReadLine();
            }
            int n = int.Parse(Console.ReadLine());

            Person comparablePerson = people[n - 1];
            int countofMatches = 0;
            int notEqualCount = 0;

            foreach (var person in people)
            {
                if (comparablePerson.CompareTo(person)==0)
                {
                    countofMatches++;
                }
                else
                {
                    notEqualCount++;
                }
            }
            if (countofMatches > 1)
            {
                Console.WriteLine($"{countofMatches} {notEqualCount} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
            

        }
    }
}
