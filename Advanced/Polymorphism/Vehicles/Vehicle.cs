using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public double FuelQuantity { get; set; }
        public double Consumption { get; set; }
        public double TankCapacity { get; set; }

        protected Vehicle(double fuelQuantity, double consumption, double tankCapacity)
        {
            
            FuelQuantity = fuelQuantity;
            Consumption = consumption;
            TankCapacity = tankCapacity;
            if (FuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
        }

        public abstract void Drive(double kilometresToTravel);
        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
