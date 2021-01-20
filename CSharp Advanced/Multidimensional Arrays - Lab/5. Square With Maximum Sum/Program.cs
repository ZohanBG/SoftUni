using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRow=0;
            int maxCol=0;

            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int sum = 0;
                    sum = matrix[row, col] + matrix[row+1, col] + matrix[row, col+1] + matrix[row+1, col+1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            for (int row = maxRow; row < maxRow+2; row++)
            {
                for (int col = maxCol; col < maxCol+2; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
