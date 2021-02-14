using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reading input
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int sRow = 0;
            int sCol = 0;
            bool isPillars = false;
            int o1Row = 0;
            int o1Col = 0;
            int o2Row = 0;
            int o2Col = 0;

            for (int row = 0; row < n; row++)
            {
                string data = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                    if (data[col] == 'S')
                    {
                        sRow = row;
                        sCol = col;
                    }
                    if (data[col] == 'O'&& !isPillars)
                    {
                        isPillars = true;
                        o1Row = row;
                        o1Col = col;
                    }
                    if(data[col] == 'O' && isPillars)
                    {
                        o2Row = row;
                        o2Col = col;
                    }
                }
            }

            //Logic
            int money = 0;
            while (true)
            {
                string command = Console.ReadLine();
                matrix[sRow, sCol] = '-';
                switch (command)
                {
                    case "up":
                        sRow--;
                        break;
                    case "down":
                        sRow++;
                        break;
                    case "left":
                        sCol--;
                        break;
                    case "right":
                        sCol++;
                        break;
                    default:
                        break;
                }

                if (sRow < 0 || sRow >= n || sCol < 0 || sCol >= n)
                {
                    break;
                }

                if (matrix[sRow, sCol] == '-')
                {
                    matrix[sRow, sCol] = 'S';
                }
                else if(matrix[sRow, sCol] == 'O')
                {
                    if (sRow == o1Row && sCol == o1Col)
                    {
                        matrix[sRow, sCol] = '-';
                        sRow = o2Row;
                        sCol = o2Col;
                        matrix[sRow, sCol] = 'S';
                    }
                    else if(sRow == o2Row && sCol == o2Col)
                    {
                        matrix[sRow, sCol] = '-';
                        sRow = o1Row;
                        sCol = o1Col;
                        matrix[sRow, sCol] = 'S';
                    }
                }
                else
                {
                    money += int.Parse(matrix[sRow, sCol].ToString());
                    matrix[sRow, sCol] = 'S';
                }
                if (money >= 50)
                {
                    break;
                }
            }

            //Output
            if (money >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {money}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}
