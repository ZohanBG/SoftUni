using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] territory = new char[n, n];
            int snakeRow = 0;
            int snakeCol = 0;
            bool isLair = false;
            int b1Row = 0;
            int b1Col = 0;
            int b2Row = 0;
            int b2Col = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = rowData[col];
                    if(territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    else if(!isLair&&territory[row, col] == 'B')
                    {
                        isLair = true;
                        b1Row = row;
                        b1Col = col;
                    }
                    else if(territory[row, col] == 'B' && isLair)
                    {
                        b2Row = row;
                        b2Col = col;
                    }           
                }
            }
            int foodCount = 0;
            while (foodCount<10)
            {
                territory[snakeRow, snakeCol] = '.';
                string input = Console.ReadLine();
                switch (input)
                {
                    case "up":
                        snakeRow--;
                        break;
                    case "down":
                        snakeRow++;
                        break;
                    case "left":
                        snakeCol--;
                        break;
                    case "right":
                        snakeCol++;
                        break;
                    default:
                        break;
                }
                if (snakeRow < 0 || snakeRow >= n || snakeCol < 0 || snakeCol >= n)
                {
                    break;
                }
                if(territory[snakeRow, snakeCol] == '*')
                {
                    foodCount++;
                }
                else if(territory[snakeRow, snakeCol] == 'B')
                {
                    territory[snakeRow, snakeCol] = '.';
                    if (snakeRow == b1Row && snakeCol == b1Col)
                    {
                        snakeRow = b2Row;
                        snakeCol = b2Col;
                    }
                    else
                    {
                        snakeRow = b1Row;
                        snakeCol = b1Col;
                    }
                }
                territory[snakeRow, snakeCol] = 'S';
            }
            if (foodCount < 10)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodCount}");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(territory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
