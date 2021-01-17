using System;

namespace _9._Yard_Greening
{
    class Program
    {
        static void Main(string[] args)
        {
            double zaOzelenqvane = double.Parse(Console.ReadLine());
            double cenaOzelenqvane = zaOzelenqvane * 7.61;
            double otstupkaOzelenqvane = 0.18 * cenaOzelenqvane;
            double krainaCena = cenaOzelenqvane - otstupkaOzelenqvane;
            Console.WriteLine($"The final price is: {krainaCena} lv.");
            Console.WriteLine($"The discount is: {otstupkaOzelenqvane} lv.");
        }
    }
}
