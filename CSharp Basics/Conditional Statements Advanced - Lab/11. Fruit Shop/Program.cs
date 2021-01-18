using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double cost = 0;
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    cost = 2.50;
                }
                else if (fruit == "apple")
                {
                    cost = 1.20;
                }
                else if (fruit == "orange")
                {
                    cost = 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    cost = 1.45;
                }
                else if (fruit == "kiwi")
                {
                    cost = 2.70;
                }
                else if (fruit == "pineapple")
                {
                    cost = 5.50;
                }
                else if (fruit == "grapes")
                {
                    cost = 3.85;
                }
                else
                {
                    cost = 0;
                }
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    cost = 2.70;
                }
                else if (fruit == "apple")
                {
                    cost = 1.25;
                }
                else if (fruit == "orange")
                {
                    cost = 0.90;
                }
                else if (fruit == "grapefruit")
                {
                    cost = 1.60;
                }
                else if (fruit == "kiwi")
                {
                    cost = 3.00;
                }
                else if (fruit == "pineapple")
                {
                    cost = 5.60;
                }
                else if (fruit == "grapes")
                {
                    cost = 4.20;
                }
                else
                {
                    cost = 0;
                }
            }

            double totalPrice = cost * amount;
            if (totalPrice > 0)
            {
                Console.WriteLine($"{totalPrice:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
