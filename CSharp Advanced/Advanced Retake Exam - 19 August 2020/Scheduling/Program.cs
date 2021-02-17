using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] queue = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> lilies = new Stack<int>(queue);
            queue = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> roses = new Queue<int>(queue);

            int flowerSum = 0;
            int wreaths = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lilie = lilies.Pop();
                int rose = roses.Dequeue();
                int sum = lilie + rose;
                if (sum > 15)
                {
                    int number = sum - 15;
                    if (number%2==1)
                    {
                        number++;
                    }
                    sum -= number;
                }
                if (sum == 15)
                {
                    wreaths++;
                }
                if (sum < 15)
                {
                    flowerSum += sum;
                }

            }
            if (flowerSum>15)
            {
                wreaths += flowerSum / 15;
            }
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }

        }
    }
}
