using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int s = input[0];
            int e = input[1];
            string criteria = Console.ReadLine();
            Func<int, int, List<int>> generator = (s, e) =>
            {
                List<int> generation = new List<int>();
                for (int i = s; i <= e; i++)
                {
                    generation.Add(i);
                }
                return generation;
            };
            List<int> numbers = generator(s, e);
            Predicate<int> filter = GetFilter(criteria);
            Console.WriteLine(string.Join(" ", FilteredNumbers(filter, numbers)));
        }

        static List<int> FilteredNumbers(Predicate<int> filter, List<int> numbers)
        {
            List<int> filteredNumbers = new List<int>();
            foreach (var num in numbers)
            {
                if (filter(num))
                {
                    filteredNumbers.Add(num);
                }
            }
            return filteredNumbers;
        }

        static Predicate<int> GetFilter(string criteria)
        {
            switch (criteria)
            {
                case "odd":
                    return n => n % 2 != 0 ;
                case "even":
                    return n => n % 2 == 0;
                default:
                    return null;
            }
        }
    }
}
