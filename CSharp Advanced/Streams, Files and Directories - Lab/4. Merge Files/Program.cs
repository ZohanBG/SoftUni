using System;
using System.IO;

namespace _4._Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readerOne = new StreamReader("../../../fileone.txt"))
            {
                string rowOne = readerOne.ReadLine();
                using (StreamReader readerTwo = new StreamReader("../../../filetwo.txt"))
                {
                    string rowTwo = readerTwo.ReadLine();
                    using(StreamWriter writer=new StreamWriter("../../../output.txt"))
                    {
                        while (rowOne != null && rowTwo != null)
                        {
                            if (rowOne != null)
                            {
                                writer.WriteLine(rowOne);
                            }
                            if (rowTwo != null)
                            {
                                writer.WriteLine(rowTwo);
                            }
                            rowOne = readerOne.ReadLine();
                            rowTwo = readerTwo.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
