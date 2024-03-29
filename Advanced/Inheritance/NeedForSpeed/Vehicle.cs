﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        public double DefaultFuelConsumption { get; set; }

        public Vehicle(int horsePower, double fuel)
        {
            DefaultFuelConsumption = 1.25;
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= DefaultFuelConsumption * kilometers;
        }
    }
}
