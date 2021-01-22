using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < n; i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[n- (1 + i) , i];
            }
            Console.WriteLine(Math.Abs(primarySum-secondarySum));
        }
    }
}
