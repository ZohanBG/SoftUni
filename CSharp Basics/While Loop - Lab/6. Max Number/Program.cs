using System;

namespace _6._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            double maxNumber = double.MinValue;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                double number = double.Parse(input);
                if (maxNumber < number)
                {
                    maxNumber = number;
                }
            }
            Console.WriteLine(maxNumber);
        }
    }
}
