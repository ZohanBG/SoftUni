using System;

namespace _6._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int crew = int.Parse(Console.ReadLine());
            double crewCostumes = double.Parse(Console.ReadLine());
            double decorPrice = budget * 0.1;
            double costumePrice = 0;
            double moneyNeeded = 0;
            if (crew <= 150)
            {
                costumePrice = crew * crewCostumes;
            }
            else
            {
                costumePrice = (crew * crewCostumes) - ((crew * crewCostumes) * 0.1);
            }
            moneyNeeded = decorPrice + costumePrice;
            if (budget < moneyNeeded)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyNeeded - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - moneyNeeded:f2} leva left.");
            }
        }
    }
}
