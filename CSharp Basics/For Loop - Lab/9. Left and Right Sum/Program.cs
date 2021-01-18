﻿using System;

namespace _9._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            int rightSum = 0;
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                leftSum += number;
            }
            for (int j = 0; j < n; j++)
            {
                int number = int.Parse(Console.ReadLine());
                rightSum += number;
            }
            if (leftSum == rightSum)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(leftSum - rightSum));

            }
        }
    }
}
