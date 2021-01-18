using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> box = new Stack<int>(input);
            int rackCapacity = int.Parse(Console.ReadLine());
            int sum = 0;
            int racks = 0;
            while (box.Count > 0)
            {
                if (box.Peek() + sum > rackCapacity)
                {
                    racks++;
                    sum = 0;
                }
                else
                {
                    sum += box.Pop();
                }
            }
            racks++;
            Console.WriteLine(racks);
        }
    }
}
