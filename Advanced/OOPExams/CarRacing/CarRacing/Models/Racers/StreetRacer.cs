using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int defaultDrivingExperience = 10;
        private const string defaultRacingBehaviour = "aggressive";
        public StreetRacer(ICar car, string username)
            : base(car, username, defaultRacingBehaviour, defaultDrivingExperience)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 5;
        }
    }
}
