using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double currentWeight = 10000;
        private const decimal currentPrice = 80;
        public Kettlebell() : base(currentWeight, currentPrice)
        {
        }
    }
}
