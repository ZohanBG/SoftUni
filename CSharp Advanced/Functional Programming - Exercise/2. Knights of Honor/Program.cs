using System;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split().Select(n => $"Sir {n}").ToArray();
            Action<string[]> printer = n => Console.WriteLine(string.Join(Environment.NewLine, n));
            printer(names);
        }
    }
}
