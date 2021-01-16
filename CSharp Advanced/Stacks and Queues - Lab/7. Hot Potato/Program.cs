using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int numberOfTosses = int.Parse(Console.ReadLine());
            Queue<string> children = new Queue<string>(input);
            int tosses = 0;
            while (children.Count > 1)
            {
                tosses++;
                if (tosses == numberOfTosses)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    tosses = 0;
                }
                else
                {
                    string child = children.Dequeue();
                    children.Enqueue(child);
                }
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
