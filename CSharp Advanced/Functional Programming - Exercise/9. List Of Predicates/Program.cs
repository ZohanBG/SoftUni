using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 1; i <=n; i++)
            {
                numbers[i - 1] = i;
            }
            int[] filters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            List<int> goodNumbers = new List<int>();
            foreach (var number in numbers)
            {
                bool isGood = true;
                foreach (var filter in filters)
                {
                    if (number % filter != 0)
                    {
                        isGood = false;
                        break;
                    }
                }
                if (isGood)
                {
                    goodNumbers.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ",goodNumbers));
        }
    }
}
