using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../../../sliceme.txt", FileMode.Open))
            {
                int chunkSize = (int)reader.Length / 4;
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;
                    using (FileStream writer = new FileStream($"../../../Part-{i+1}.txt", FileMode.Create,FileAccess.Write))
                    {
                        while (count < chunkSize)
                        {
                            reader.Read(buffer, 0, buffer.Length);
                            writer.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }
                    }
                }
            }
        }
    }
}
