using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            //filling matrix
            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            int removed = 0;
            while (true)
            {
                int maxAttakings = 0;
                int maxRow = 0;
                int maxCol = 0;
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int attakings = 0;
                            //-2 1
                            if (row - 2 >= 0 && col + 1 < n && matrix[row - 2, col + 1]=='K')
                            {
                                attakings++;
                            }
                            //-2 -1
                            if (row - 2 >= 0 && col -1  >= 0 && matrix[row - 2, col - 1] == 'K')
                            {
                                attakings++;
                            }
                            //-1 2
                            if (row - 1 >= 0 && col + 2 < n && matrix[row - 1, col + 2] == 'K')
                            {
                                attakings++;
                            }
                            //-1 -2
                            if (row - 1 >= 0 && col - 2 >=0 && matrix[row - 1, col - 2] == 'K')
                            {
                                attakings++;
                            }
                            //2 -1
                            if (row + 2 < n && col - 1 >=0 && matrix[row + 2, col - 1] == 'K')
                            {
                                attakings++;
                            }
                            //2 1
                            if (row + 2 < n && col + 1 < n && matrix[row + 2, col + 1] == 'K')
                            {
                                attakings++;
                            }
                            //1 -2
                            if (row + 1 < n && col - 2 >=0 && matrix[row + 1, col - 2] == 'K')
                            {
                                attakings++;
                            }
                            //1 2
                            if (row + 1 < n && col + 2 < n && matrix[row + 1, col + 2] == 'K')
                            {
                                attakings++;
                            }

                            if (maxAttakings < attakings)
                            {
                                maxAttakings = attakings;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxAttakings > 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    removed++;
                }
                else
                {
                    Console.WriteLine(removed);
                    break;
                }
            }
        }
    }
}
