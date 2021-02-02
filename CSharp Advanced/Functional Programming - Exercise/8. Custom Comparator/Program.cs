using System;
using System.Linq;

namespace _8._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] evenNums = numbers.Where(n => n % 2 == 0).ToArray();
            Array.Sort(evenNums);
            int[] oddNums = numbers.Where(n => n % 2 != 0).ToArray();
            Array.Sort(oddNums);
            int[] orderedNums = evenNums.Concat(oddNums).ToArray();
            Console.WriteLine(string.Join(" ",orderedNums));
        }
    }
}
