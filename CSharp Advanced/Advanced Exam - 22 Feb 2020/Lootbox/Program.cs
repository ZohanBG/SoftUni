using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> firstBox = new Queue<int>(input);
            input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> secondBox = new Stack<int>(input);
            int valueSum = 0;
            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int sum = firstBox.Peek() + secondBox.Peek();
                if (sum % 2 == 0)
                {
                    valueSum += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            if (firstBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (valueSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {valueSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {valueSum}");
            }
        }
    }
}
