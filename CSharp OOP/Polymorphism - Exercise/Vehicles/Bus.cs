using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vechicle
    {
        private const double fuelConsumptionIncrease = 1.4;

        public Bus(double quantity, double consumption, double tankCapacity) 
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
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public void DriveEmpty(double distance)
        {
            double fuelNeeded = FuelConsumption * distance;
            if (fuelNeeded > FuelQuantity)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount <= TankCapacity)
            {
                FuelQuantity += amount;
            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
