﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int gymCap = 15;
        public BoxingGym(string name) : base(name, gymCap)
        {
        }
    }
}
