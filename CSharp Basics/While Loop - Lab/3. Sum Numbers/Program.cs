using System;

namespace _3._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int numberSum = 0;
            while (number > numberSum)
            {
                int number2 = int.Parse(Console.ReadLine());
                numberSum += number2;
            }
            Console.WriteLine(numberSum);
        }
    }
}
