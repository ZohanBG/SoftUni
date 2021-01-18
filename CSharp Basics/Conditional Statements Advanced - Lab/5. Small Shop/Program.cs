using System;

namespace _5._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            if (product == "coffee")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(amount * 0.50);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(amount * 0.40);
                }
                else
                {
                    Console.WriteLine(amount * 0.45);
                }
            }
            if (product == "water")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(amount * 0.80);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(amount * 0.70);
                }
                else
                {
                    Console.WriteLine(amount * 0.70);
                }
            }
            if (product == "beer")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(amount * 1.20);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.15);
                }
                else
                {
                    Console.WriteLine(amount * 1.10);
                }
            }
            if (product == "sweets")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(amount * 1.45);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.30);
                }
                else
                {
                    Console.WriteLine(amount * 1.35);
                }
            }
            if (product == "peanuts")
            {
                if (city == "Sofia")
                {
                    Console.WriteLine(amount * 1.60);
                }
                else if (city == "Plovdiv")
                {
                    Console.WriteLine(amount * 1.50);
                }
                else
                {
                    Console.WriteLine(amount * 1.55);
                }
            }
        }
    }
}
