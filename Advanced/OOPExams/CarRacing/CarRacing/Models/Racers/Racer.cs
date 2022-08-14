using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehaviour;
        private int drivingExperience;
        private ICar car;

        protected Racer(ICar car, string username, string racingBehavior, int drivingExperience)
        {
            this.car = car;
            Username = username;
            RacingBehavior = racingBehavior;
            DrivingExperience = drivingExperience;
        }

        public string Username 
        {
            get { return username; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }

        public string RacingBehavior 
        {
            get { return racingBehaviour; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehaviour = value;
            }
        }

        public int DrivingExperience 
        {
            get { return drivingExperience; }
            protected set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }

        public ICar Car => car;

        public bool IsAvailable() => car.FuelAvailable >= car.FuelConsumptionPerRace;

        public virtual void Race()
        {
            car.Drive();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}: {this.Username}"+ Environment.NewLine)
                .Append($"--Driving behavior: {this.RacingBehavior}" + Environment.NewLine)
                .Append($"--Driving experience: {this.DrivingExperience}" + Environment.NewLine)
                .Append($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})" + Environment.NewLine);
            return sb.ToString().TrimEnd();
        }
    }
}
