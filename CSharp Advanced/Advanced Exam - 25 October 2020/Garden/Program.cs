using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int gardenRow = size[0];
            int gardenCol = size[1];

            int[,] garden = new int[gardenRow, gardenCol];

            string input = Console.ReadLine();

            while (input!= "Bloom Bloom Plow")
            {
                int[] flowerPosition = input.Split()
                    .Select(int.Parse)
                    .ToArray();
                int flowerRow = flowerPosition[0];
                int flowerCol = flowerPosition[1];
                if (flowerRow < 0 || flowerRow >= gardenRow || flowerCol < 0 || flowerCol >= gardenCol)
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    for (int row = 0; row < gardenRow; row++)
                    {
                        for (int col = 0; col < gardenCol; col++)
                        {
                            if (row == flowerRow || col == flowerCol)
                            {
                                garden[row, col]++;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            for (int row = 0; row < gardenRow; row++)
            {
                for (int col = 0; col < gardenCol; col++)
                {
                    Console.Write(garden[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
