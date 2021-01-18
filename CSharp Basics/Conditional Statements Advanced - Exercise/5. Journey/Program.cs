using System;

namespace _5._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string destination = "";
            string type = "";
            double moneyNeeded = 0;
            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    moneyNeeded = budget * 0.3;
                    type = "Camp";
                }
                else
                {
                    moneyNeeded = budget * 0.7;
                    type = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    moneyNeeded = budget * 0.4;
                    type = "Camp";
                }
                else
                {
                    moneyNeeded = budget * 0.8;
                    type = "Hotel";
                }
            }
            else
            {
                destination = "Europe";
                type = "Hotel";
                moneyNeeded = budget * 0.9;
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{type} - {moneyNeeded:f2}");
        }
    }
}
