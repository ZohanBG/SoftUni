using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int lineCount = 1;
            foreach (string line in lines)
            {
                int letterCount = 0;
                int punctuationCount = 0;
                foreach (char ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        letterCount++;
                    }
                    if (char.IsPunctuation(ch))
                    {
                        punctuationCount++;
                    }
                }
                string updatedLine = $"Line {lineCount}: {line} ({letterCount})({punctuationCount})";
                File.AppendAllText("../../../output.txt",updatedLine+Environment.NewLine);
                lineCount++;
            }
        }
    }
}
