using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = matrixData[0];
            int cols = matrixData[1];
            char[,] matrix = new char[rows,cols];
            string snake = Console.ReadLine();
            int count = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[count];
                        count++;
                        if (count >= snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
                if (row % 2 == 1)
                {
                    for (int col = cols-1; col >=0; col--)
                    {
                        matrix[row, col] = snake[count];
                        count++;
                        if (count >= snake.Length)
                        {
                            count = 0;
                        }
                    }
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
