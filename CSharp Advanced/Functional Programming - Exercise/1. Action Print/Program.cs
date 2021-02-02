using System;
using System.Linq;

namespace _1._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            Action<string[]> printer = n => Console.WriteLine(string.Join(Environment.NewLine, n));
            printer(names);
        }
    }
}
