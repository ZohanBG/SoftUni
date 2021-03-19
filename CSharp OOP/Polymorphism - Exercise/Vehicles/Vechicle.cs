using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vechicle
    {
        public Vechicle(double quantity, double consumption, double tankCapacity)
        {
            FuelQuantity = quantity;
            FuelConsumption = consumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption  { get; set; }

        public double TankCapacity { get; set; }

        public abstract void Drive(double distance);

        public abstract void Refuel(double amount);
    }
}
