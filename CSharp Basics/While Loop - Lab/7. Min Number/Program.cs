using System;

namespace _7._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double minNumber = double.MaxValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                double number = double.Parse(input);
                if (minNumber > number)
                {
                    minNumber = number;
                }
            }
            Console.WriteLine(minNumber);
        }
    }
}
