using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
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
            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if(row<0||row>=n|| col < 0 || col >= n)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        matrix[row, col] += value;
                    }
                    else if(command[0]== "Subtract")
                    {
                        matrix[row, col] -= value;
                    }
                }
                command = Console.ReadLine().Split();
            }
            for (int row = 0; row < n; row++)
            {

                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
