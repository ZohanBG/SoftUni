using System;
using System.IO;

namespace _4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream reader = new FileStream("../../../copyMe.png",FileMode.Open);
            FileStream writer = new FileStream("../../../copy.png", FileMode.Create);
            while (reader.Position < reader.Length)
            {
                byte[] buffer = new byte[4096];
                reader.Read(buffer);
                writer.Write(buffer);
            }
        }
    }
}
