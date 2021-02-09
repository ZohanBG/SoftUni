using System;
using System.Collections.Generic;

namespace GenericCount
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();
            for (int i = 0; i < n; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }
            Count<double> count = new Count<double>(elements);
            Console.WriteLine(count.CountElements(double.Parse(Console.ReadLine())));
        }
    }
}
