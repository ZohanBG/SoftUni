using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double money = double.Parse(Console.ReadLine());
            double commisionPersent = 0;
            if (city == "Sofia")
            {
                if (money >= 0 && money <= 500)
                {
                    commisionPersent = 0.05;
                }
                else if (money > 500 && money <= 1000)
                {
                    commisionPersent = 0.07;
                }
                else if (money > 1000 && money <= 10000)
                {
                    commisionPersent = 0.08;
                }
                else if (money > 10000)
                {
                    commisionPersent = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (money >= 0 && money <= 500)
                {
                    commisionPersent = 0.045;
                }
                else if (money > 500 && money <= 1000)
                {
                    commisionPersent = 0.075;
                }
                else if (money > 1000 && money <= 10000)
                {
                    commisionPersent = 0.10;
                }
                else if (money > 10000)
                {
                    commisionPersent = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (money >= 0 && money <= 500)
                {
                    commisionPersent = 0.055;
                }
                else if (money > 500 && money <= 1000)
                {
                    commisionPersent = 0.08;
                }
                else if (money > 1000 && money <= 10000)
                {
                    commisionPersent = 0.12;
                }
                else if (money > 10000)
                {
                    commisionPersent = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            double commision = money * commisionPersent;
            if (commisionPersent > 0)
            {
                Console.WriteLine($"{commision:f2}");
            }
        }
    }
}
