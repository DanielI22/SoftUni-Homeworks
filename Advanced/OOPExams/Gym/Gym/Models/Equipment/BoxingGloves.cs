using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double currentWeight = 227;
        private const decimal currentPrice = 120;
        public BoxingGloves() : base(currentWeight, currentPrice)
        {

        }
    }
}
