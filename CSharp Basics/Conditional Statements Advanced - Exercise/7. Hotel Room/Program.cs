using System;

namespace _7._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double apartamentPrice = 0;
            if (month == "May" || month == "October")
            {
                studioPrice = 50 * nights;
                apartamentPrice = 65 * nights;
                if (nights > 7 && nights <= 14)
                {
                    studioPrice = studioPrice * 0.95;
                }
                else if (nights > 14)
                {
                    studioPrice = studioPrice * 0.70;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20 * nights;
                apartamentPrice = 68.70 * nights;
                if (nights > 14)
                {
                    studioPrice = studioPrice * 0.80;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76 * nights;
                apartamentPrice = 77 * nights;
            }
            if (nights > 14)
            {
                apartamentPrice = apartamentPrice * 0.90;
            }
            Console.WriteLine($"Apartment: {apartamentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
