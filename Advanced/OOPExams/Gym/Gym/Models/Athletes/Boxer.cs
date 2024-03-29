﻿using System;
using System.Collections.Generic;
using Gym.Utilities.Messages;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        private const int initialStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, initialStamina, numberOfMedals)
        {
        }
        public override void Exercise()
        {
            Stamina += 15;
            if(Stamina > 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
