using System;

namespace _2._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    int result = x * y;
                    Console.WriteLine($"{x} * {y} = {result}");
                }
            }
        }
    }
}
