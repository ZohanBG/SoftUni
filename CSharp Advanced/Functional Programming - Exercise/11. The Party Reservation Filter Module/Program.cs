using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> startsWith = new List<string>();
            List<string> endsWith = new List<string>();
            List<int> lengthIs = new List<int>();
            List<string> contains = new List<string>();
            string[] tokens = Console.ReadLine().Split(";");
            while (tokens[0]!="Print")
            {
                string command = tokens[0];
                string filterType = tokens[1];
                string filterParameter = tokens[2];
                switch (command)
                {
                    case "Add filter":
                        switch (filterType)
                        {
                            case "Starts with":
                                if (!startsWith.Contains(filterParameter))
                                {
                                    startsWith.Add(filterParameter);
                                }
                                break;
                            case "Ends with":
                                if (!endsWith.Contains(filterParameter))
                                {
                                    endsWith.Add(filterParameter);
                                }
                                break;
                            case "Length":
                                if (!lengthIs.Contains(int.Parse(filterParameter)))
                                {
                                    lengthIs.Add(int.Parse(filterParameter));
                                }
                                break;
                            case "Contains":
                                if (!contains.Contains(filterParameter))
                                {
                                    contains.Add(filterParameter);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Remove filter":
                        switch (filterType)
                        {
                            case "Starts with":
                                startsWith.Remove(filterParameter);
                                break;
                            case "Ends with":
                                endsWith.Remove(filterParameter);
                                break;
                            case "Length":
                                lengthIs.Remove(int.Parse(filterParameter));
                                break;
                            case "Contains":
                                contains.Remove(filterParameter);
                                break;
                            default:
                                break;
                        }
                        break;                  
                    default:
                        break;
                }
                tokens = Console.ReadLine().Split(";");
            }
            foreach (var item in startsWith)
            {
                people = people.Where(n => !n.StartsWith(item)).ToList();
            }
            foreach (var item in endsWith)
            {
                people = people.Where(n => !n.EndsWith(item)).ToList();
            }
            foreach (var item in lengthIs)
            {
                people = people.Where(n => n.Length!=item).ToList();
            }
            foreach (var item in contains)
            {
                people = people.Where(n => !n.Contains(item)).ToList();
            }
            Console.WriteLine(string.Join(" ",people));
        }
    }
}
