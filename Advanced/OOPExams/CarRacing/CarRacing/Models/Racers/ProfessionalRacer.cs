using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int defaultDrivingExperience = 30;
        private const string defaultRacingBehaviour = "strict";
        public ProfessionalRacer(ICar car, string username)
            : base(car, username, defaultRacingBehaviour, defaultDrivingExperience)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
