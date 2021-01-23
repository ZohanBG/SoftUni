using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> n = new HashSet<int>();
            HashSet<int> m = new HashSet<int>();            
            for (int i = 0; i < input[0]; i++)
            {
                n.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input[1]; i++)
            {
                m.Add(int.Parse(Console.ReadLine()));
            }
            HashSet<int> nAndM = new HashSet<int>(n.Intersect(m));
            Console.WriteLine(string.Join(" ",nAndM));
        }
    }
}
