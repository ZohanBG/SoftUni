using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            Lake myLake = new Lake(stones);

            Console.WriteLine(string.Join(", ",myLake));
        }
    }
}
