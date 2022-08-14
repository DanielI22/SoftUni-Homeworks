using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        private const double defaultAvailableFuel = 80;
        private const double defaultConsumptionRate = 10;
        public SuperCar(string make, string model, string vin, int horsePower) 
            : base(make, model, vin, horsePower, defaultAvailableFuel, defaultConsumptionRate)
        {
        }
    }
}
