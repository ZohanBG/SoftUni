using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = commands[0];
            int s = commands[1];
            int x = commands[2];
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Push(input[i]);
            }
            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }
            if (numbers.Count > 0 && numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
