using System;
using System.Linq;

namespace _6._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int filter = int.Parse(Console.ReadLine());
            Func< int, bool> criteria = n => n % filter != 0;
            numbers = numbers.Where(criteria).ToArray();
            Action<int[]> printer = n => Console.WriteLine(string.Join(" ",n));
            printer(numbers);
        }
    }
}
