using CarRacing.Models.Maps.Contracts;
using CarRacing.Utilities.Messages;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable() && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else
            {
                double racerOneChance = chanceOfWinningCalculator(racerOne.Car.HorsePower, racerOne.DrivingExperience, racerOne.RacingBehavior);
                double racerTwoChance = chanceOfWinningCalculator(racerTwo.Car.HorsePower, racerTwo.DrivingExperience, racerTwo.RacingBehavior);
                racerOne.Race();
                racerTwo.Race();
                if (racerOneChance > racerTwoChance)
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
                }
                else
                {
                    return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
                }
            }

        }

        private double racingMultiplierCalculator(string behavior)
        {
            if(behavior == "strict")
            {
                return 1.2;
            }
            else if(behavior == "aggressive")
            {
                return 1.1;
            }
            return 1;
        }

        private double chanceOfWinningCalculator(int horsePower, int drivingExp, string behaviour)
        {
            return horsePower*drivingExp*racingMultiplierCalculator(behaviour);
        }
    }
}
