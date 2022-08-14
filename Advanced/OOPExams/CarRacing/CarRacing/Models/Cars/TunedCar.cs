using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double defaultAvailableFuel = 65;
        private const double defaultConsumptionRate = 7.5;
        public TunedCar(string make, string model, string vin, int horsePower)
            : base(make, model, vin, horsePower, defaultAvailableFuel, defaultConsumptionRate)
        {
        }

        public override void Drive()
        {
            base.Drive();
            HorsePower = (int)Math.Round(HorsePower * 0.97);
        }
    }
}
