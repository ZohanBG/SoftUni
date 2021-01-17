using System;

namespace _1._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int sp1 = int.Parse(Console.ReadLine());
            int sp2 = int.Parse(Console.ReadLine());
            int sp3 = int.Parse(Console.ReadLine());
            int minutes = (sp1 + sp2 + sp3) / 60;
            int sec = (sp1 + sp2 + sp3) % 60;

            if (sec < 10)
            {
                Console.WriteLine($"{minutes}:0{sec}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{sec}");
            }
        }
    }
}
