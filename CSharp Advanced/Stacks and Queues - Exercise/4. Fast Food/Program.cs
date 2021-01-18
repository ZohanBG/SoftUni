using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(input);
            Console.WriteLine(orders.Max());
            while (orders.Count>0)
            {
                if (orders.Peek()<=food)
                {
                    food -= orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ",orders));
            }
        }
    }
}
