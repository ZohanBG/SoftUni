using System;

namespace _5._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "NoMoreMoney")
                {
                    break;
                }
                double number = double.Parse(input);
                if (number < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {number:f2}");
                total += number;
            }
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
