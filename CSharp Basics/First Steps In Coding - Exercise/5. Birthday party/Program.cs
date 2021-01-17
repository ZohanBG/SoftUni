using System;

namespace _5._Birthday_party
{
    class Program
    {
        static void Main(string[] args)
        {
            double zala = double.Parse(Console.ReadLine());
            double torta = zala / 5;
            double napitki = torta - (torta * 0.45);
            double animator = zala / 3;
            Console.WriteLine(zala + torta + napitki + animator);
        }
    }
}
