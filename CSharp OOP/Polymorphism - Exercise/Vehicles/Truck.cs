using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vechicle
    {
        private const double fuelLost = 0.95;
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double quantity, double consumption, double tankCapacity) 
            : base(quantity, consumption, tankCapacity)
        {
            if (TankCapacity < FuelQuantity)
            {
                FuelQuantity = 0;
            }
        }

        public override void Drive(double distance)
        {
            double fuelNeeded = (FuelConsumption + fuelConsumptionIncrease) * distance;
            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount*fuelLost <= TankCapacity)
            {
                FuelQuantity += amount*fuelLost;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
