using System;

namespace _3._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            int money = int.Parse(Console.ReadLine());
            double moneyNeeded = 0;
            if (type == "Roses")
            {
                moneyNeeded = count * 5;
                if (count > 80)
                {
                    moneyNeeded = moneyNeeded * 0.9;
                }
            }
            else if (type == "Dahlias")
            {
                moneyNeeded = count * 3.80;
                if (count > 90)
                {
                    moneyNeeded = moneyNeeded * 0.85;
                }
            }
            else if (type == "Tulips")
            {
                moneyNeeded = count * 2.80;
                if (count > 80)
                {
                    moneyNeeded = moneyNeeded * 0.85;
                }
            }
            else if (type == "Narcissus")
            {
                moneyNeeded = count * 3;
                if (count < 120)
                {
                    moneyNeeded = moneyNeeded * 1.15;
                }
            }
            else
            {
                moneyNeeded = count * 2.50;
                if (count < 80)
                {
                    moneyNeeded = moneyNeeded * 1.20;
                }
            }
            if (money >= moneyNeeded)
            {
                Console.WriteLine($"Hey, you have a great garden with {count} {type} and {(money - moneyNeeded):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(moneyNeeded - money):f2} leva more.");
            }
        }
    }
}
