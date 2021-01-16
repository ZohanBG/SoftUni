using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(array);          
            string[] command = Console.ReadLine().ToLower().Split();
            while (command[0] != "end")
            {
                if (command[0] == "add")
                {
                    numbers.Push(int.Parse(command[1]));
                    numbers.Push(int.Parse(command[2]));
                }
                else if (command[0] == "remove")
                {
                    int remove = int.Parse(command[1]);
                    if (numbers.Count >= remove)
                    {
                        for (int i = 0; i < remove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower().Split();
            }
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
