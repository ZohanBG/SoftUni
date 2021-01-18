using System;

namespace _2._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int bigNumber = int.MinValue;
            int sumNumber = 0;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sumNumber += number;
                if (bigNumber < number)
                {
                    bigNumber = number;
                }
            }
            sumNumber = sumNumber - bigNumber;
            if (sumNumber == bigNumber)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + sumNumber);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + Math.Abs(sumNumber - bigNumber));
            }
        }
    }
}
