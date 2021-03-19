using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] vechicleData = Console.ReadLine().Split();
            Car car = new Car(double.Parse(vechicleData[1]), double.Parse(vechicleData[2]), double.Parse(vechicleData[3]));
            vechicleData = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(vechicleData[1]), double.Parse(vechicleData[2]), double.Parse(vechicleData[3]));
            vechicleData = Console.ReadLine().Split();
            Bus bus = new Bus(double.Parse(vechicleData[1]), double.Parse(vechicleData[2]), double.Parse(vechicleData[3]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Drive")
                {
                    if (input[1] == nameof(Car))
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else if (input[1]== nameof(Truck))
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == nameof(Bus))
                    {
                        bus.Drive(double.Parse(input[2]));
                    }
                }
                else if(input[0]== "Refuel")
                {
                    if (input[1] == nameof(Car))
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == nameof(Truck))
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == nameof(Bus))
                    {
                        bus.Refuel(double.Parse(input[2]));
                    }
                }
                else if(input[0]== "DriveEmpty" && input[1] == nameof(Bus))
                {
                    bus.DriveEmpty(double.Parse(input[2]));
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");

        }
    }
}
