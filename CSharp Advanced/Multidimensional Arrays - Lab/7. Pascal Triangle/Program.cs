using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascal = new long[n][];
            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];
                for (int col = 0; col < row+1; col++)
                {
                    pascal[row][col] = row + col;
                }
            }

            for (int row = 0; row < pascal.Length; row++)
            {

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write(pascal[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
