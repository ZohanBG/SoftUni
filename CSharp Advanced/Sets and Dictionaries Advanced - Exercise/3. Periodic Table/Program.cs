using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> elements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in input)
                {
                    elements.Add(element);
                }
            }
            elements = elements.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ",elements));
        }
    }
}
