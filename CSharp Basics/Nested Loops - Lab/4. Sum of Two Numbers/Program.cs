using System;

namespace _4._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            bool magic = false;
            for (int x = start; x <= finish; x++)
            {
                for (int y = start; y <= finish; y++)
                {
                    counter++;
                    int result = x + y;
                    if (result == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{counter} ({x} + {y} = {magicNumber})");
                        magic = true;
                        break;
                    }
                }
                if (magic)
                {
                    break;
                }
            }
            if (magic == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
        }
    }
}
