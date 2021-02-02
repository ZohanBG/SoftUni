using System;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, decimal> parser = n => decimal.Parse(n);
            Func<decimal, decimal> vat = n => n * 1.2m;
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser)
                .Select(vat)
                .ToArray();
            foreach (decimal number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
