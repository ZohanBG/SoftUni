using System;

namespace _4._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int start = 1;
            while (n >= start)
            {
                Console.WriteLine(start);
                start = start * 2 + 1;
            }
        }
    }
}
