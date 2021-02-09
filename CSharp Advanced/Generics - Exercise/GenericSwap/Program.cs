using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwap
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> elements = new List<int>();
            for (int i = 0; i < n; i++)
            {
                elements.Add(int.Parse(Console.ReadLine()));
            }
            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Swap<int> swap = new Swap<int>(elements, indexes[0], indexes[1]);
            Console.WriteLine(swap);
        }
    }
}
