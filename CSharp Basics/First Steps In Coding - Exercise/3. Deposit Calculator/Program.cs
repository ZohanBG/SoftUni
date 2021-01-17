using System;

namespace _3._Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depoziranaSuma = double.Parse(Console.ReadLine());
            int meseci = int.Parse(Console.ReadLine());
            double lihva = double.Parse(Console.ReadLine());
            Double lihvaVprocenti = lihva / 100;
            double natrupanaLihva = depoziranaSuma * lihvaVprocenti;
            double lihvaZa1mesec = natrupanaLihva / 12;
            double suma = depoziranaSuma + (meseci * lihvaZa1mesec);
            Console.WriteLine(suma);
        }
    }
}
