using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            bool isThere = false;
            char symbol = char.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isThere = true;
                        break;
                    }
                }
                if (isThere)
                {
                    break;
                }
            }
            if (!isThere)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
