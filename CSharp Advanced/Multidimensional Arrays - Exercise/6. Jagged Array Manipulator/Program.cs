using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jagged = new double[n][];
            //inputting jagged:
            for (int row = 0; row < n; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = new double[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    jagged[row][col] = rowData[col];
                }
            }
            //analysing:
            for (int row = 0; row < n-1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *=  2;
                        jagged[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /=  2;
                    }
                    for (int col = 0; col < jagged[row+1].Length; col++)
                    {
                        jagged[row+1][col] /=  2;
                    }
                }
            }
            //Commands:
            string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "End")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row >= 0 && row < n && col >= 0 && col < jagged[row].Length)
                {
                    switch (command[0])
                    {
                        case "Add":
                            jagged[row][col] += value;
                            break;
                        case "Subtract":
                            jagged[row][col] -= value;
                            break;
                        default:
                            break;
                    }
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            //outputting jagged:
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(jagged[row][col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
