using System;

namespace _3._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());
            int daysCounter = 0;
            int spendingCounter = 0;
            while (true)
            {
                string comand = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                daysCounter++;
                if (comand == "save")
                {
                    ownedMoney += money;
                    spendingCounter = 0;
                }
                else if (comand == "spend")
                {
                    spendingCounter++;
                    ownedMoney -= money;
                    if (ownedMoney < 0)
                    {
                        ownedMoney = 0;
                    }
                }
                if (spendingCounter >= 5)
                {
                    Console.WriteLine("You can't save the money.");
                    Console.WriteLine($"{daysCounter}");
                    break;
                }
                if (ownedMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {daysCounter} days.");
                    break;
                }
            }
        }
    }
}
