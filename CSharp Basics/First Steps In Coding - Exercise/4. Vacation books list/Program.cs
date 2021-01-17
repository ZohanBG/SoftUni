using System;

namespace _4._Vacation_books_list
{
    class Program
    {
        static void Main(string[] args)
        {
            int broiStranici = int.Parse(Console.ReadLine());
            double straniciZaChas = double.Parse(Console.ReadLine());
            int broiDni = int.Parse(Console.ReadLine());
            double broiChasoveNaDen = (broiStranici / straniciZaChas) / broiDni;
            Console.WriteLine(broiChasoveNaDen);
        }
    }
}
