using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using(StreamReader reader=new StreamReader("../../../input.txt"))
            {
                string currentRow = reader.ReadLine();
                int rowNumber = 1;
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (currentRow!=null)
                    {
                        writer.WriteLine($"{rowNumber}. {currentRow}");
                        currentRow = reader.ReadLine();
                        rowNumber++;
                    }
                }
            }
        }
    }
}
