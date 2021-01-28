using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader=new StreamReader("../../../input.txt"))
            {
                int rowCount = 0;
                string currentRow = reader.ReadLine();
                using(StreamWriter write=new StreamWriter("../../../output.txt"))
                {
                    while (currentRow != null)
                    {
                        if (rowCount % 2 == 1)
                        {
                            write.WriteLine(currentRow);
                        }
                        currentRow = reader.ReadLine();
                        rowCount++;
                    }
                }
            }
        }
    }
}
