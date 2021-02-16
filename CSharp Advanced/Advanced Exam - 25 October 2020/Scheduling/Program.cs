using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading input
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            Stack<int> tasks = new Stack<int>(input);
            input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> threads = new Queue<int>(input);
            int killerTask = int.Parse(Console.ReadLine());

            //Logic
            while (killerTask != tasks.Peek())
            {
                if (threads.Peek() >= tasks.Peek())
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

            //Output
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {killerTask}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
