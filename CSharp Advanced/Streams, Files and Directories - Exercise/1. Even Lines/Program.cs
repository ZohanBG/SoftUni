using System;
using System.IO;
using System.Linq;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string currentLine = reader.ReadLine();
                int lineCount = 0;
                while (currentLine != null)
                {
                    if (lineCount % 2 == 0)
                    {
                        string replacingLine = string.Join('@', currentLine.Split('-', ',', '.', '!', '?'));
                        string reverseLine = string.Join(" ", replacingLine.Split().Reverse().ToArray());
                        Console.WriteLine(reverseLine);
                    }
                    lineCount++;
                    currentLine = reader.ReadLine();
                }
            }

        }
    }
}
