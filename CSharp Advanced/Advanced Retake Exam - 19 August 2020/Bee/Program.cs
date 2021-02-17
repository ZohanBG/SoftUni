using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] beeTerritory = new char[n, n];

            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < n; row++)
            {
                string rowData = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    beeTerritory[row, col] = rowData[col];
                    if(beeTerritory[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            int flowerCount = 0;
            string input = Console.ReadLine();
            while (input != "End")
            {
                beeTerritory[beeRow, beeCol] = '.';
                switch (input)
                {
                    case "up":
                        beeRow--;
                        break;
                    case "down":
                        beeRow++;
                        break;
                    case "left":
                        beeCol--;
                        break;
                    case "right":
                        beeCol++;
                        break;
                    default:
                        break;
                }
                if (beeRow < 0 || beeRow >= n || beeCol < 0 || beeCol >= n)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if(beeTerritory[beeRow, beeCol] == 'f')
                {
                    flowerCount++;             
                }
                else if(beeTerritory[beeRow, beeCol] == 'O')
                {
                    beeTerritory[beeRow, beeCol] = '.';
                    switch (input)
                    {
                        case "up":
                            beeRow--;
                            break;
                        case "down":
                            beeRow++;
                            break;
                        case "left":
                            beeCol--;
                            break;
                        case "right":
                            beeCol++;
                            break;
                        default:
                            break;
                    }
                    if (beeTerritory[beeRow, beeCol] == 'f')
                    {
                        flowerCount++;
                    }
                }
                beeTerritory[beeRow, beeCol] = 'B';
                input = Console.ReadLine();
            }
            if (flowerCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-flowerCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerCount} flowers!");
            }
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(beeTerritory[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
