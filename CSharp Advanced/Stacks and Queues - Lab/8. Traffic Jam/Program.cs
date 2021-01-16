using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfCarsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string car = Console.ReadLine();
            int count = 0;
            while (car != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < numOfCarsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }
                car = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
