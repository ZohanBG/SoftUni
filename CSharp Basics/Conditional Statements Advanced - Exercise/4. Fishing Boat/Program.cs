using System;

namespace _4._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int numberOfFishers = int.Parse(Console.ReadLine());
            double moneyNeeded = 0;
            if (season == "Spring")
            {
                if (numberOfFishers <= 6)
                {
                    moneyNeeded = 3000 * 0.9;
                }
                else if (numberOfFishers > 6 && numberOfFishers <= 11)
                {
                    moneyNeeded = 3000 * 0.85;
                }
                else
                {
                    moneyNeeded = 3000 * 0.75;
                }
            }
            else if (season == "Summer" || season == "Autumn")
            {
                if (numberOfFishers <= 6)
                {
                    moneyNeeded = 4200 * 0.9;
                }
                else if (numberOfFishers > 6 && numberOfFishers <= 11)
                {
                    moneyNeeded = 4200 * 0.85;
                }
                else
                {
                    moneyNeeded = 4200 * 0.75;
                }
            }
            else
            {
                if (numberOfFishers <= 6)
                {
                    moneyNeeded = 2600 * 0.9;
                }
                else if (numberOfFishers > 6 && numberOfFishers <= 11)
                {
                    moneyNeeded = 2600 * 0.85;
                }
                else
                {
                    moneyNeeded = 2600 * 0.75;
                }
            }
            if (numberOfFishers % 2 == 0 && season != "Autumn")
            {
                moneyNeeded = moneyNeeded * 0.95;
            }
            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"Yes! You have {(budget - moneyNeeded):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(moneyNeeded - budget):f2} leva.");
            }
        }
    }
}
