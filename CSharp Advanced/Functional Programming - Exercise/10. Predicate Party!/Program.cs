using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            string[] command = Console.ReadLine().Split();
            Func<string, string, bool> startsWith = (w, c) => w.StartsWith(c);
            Func<string, string, bool> endsWith = (w, c) => w.EndsWith(c);
            Func<string, int, bool> lenght = (w, l) => w.Length == l;
            while (command[0]!= "Party!")
            {

                switch (command[0])
                {
                    case "Remove":
                        if(command[1]== "StartsWith")
                        {
                            people = people.Where(n => !startsWith(n, command[2])).ToList();
                        }
                        else if(command[1] == "EndsWith")
                        {
                            people = people.Where(n => !endsWith(n, command[2])).ToList();
                        }
                        else if (command[1] == "Length")
                        {
                            people = people.Where(n => !lenght(n, int.Parse(command[2]))).ToList();
                        }
                        break;
                    case "Double":
                        if (command[1] == "StartsWith")
                        {
                            List<string> temp = people.Where(name => startsWith(name, command[2])).ToList();
                            foreach (var item in temp)
                            {
                                int index = people.IndexOf(item);
                                people.Insert(index, item);
                            }
                        }
                        else if (command[1] == "EndsWith")
                        {
                            List<string> temp = people.Where(name => endsWith(name, command[2])).ToList();
                            foreach (var item in temp)
                            {
                                int index = people.IndexOf(item);
                                people.Insert(index, item);
                            }
                        }
                        else if (command[1] == "Length")
                        {
                            List<string> temp = people.Where(name => lenght(name, int.Parse(command[2]))).ToList();
                            foreach (var item in temp)
                            {
                                int index = people.IndexOf(item);
                                people.Insert(index, item);
                            }
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split();
            }
            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
