using System;
using System.Collections.Generic;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string[] command = Console.ReadLine().Split(", ");
            while (command[0] != "END")
            {
                if (command[0] == "IN")
                {
                    cars.Add(command[1]);
                }
                else
                {
                    cars.Remove(command[1]);
                }
                command = Console.ReadLine().Split(", ");
            }
            if (cars.Count != 0)
            {
                foreach (string car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
