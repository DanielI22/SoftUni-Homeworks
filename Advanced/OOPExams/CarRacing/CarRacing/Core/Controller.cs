using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository carRepository;
        private RacerRepository racerRepository;
        private IMap map;

        public Controller()
        {
            this.carRepository = new CarRepository();
            this.racerRepository = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if(type != nameof(SuperCar) && type != nameof(TunedCar))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }
            else if(type == nameof(SuperCar))
            {
                carRepository.Add(new SuperCar(make, model, VIN, horsePower));
            }
            else if (type == nameof(TunedCar))
            {
                carRepository.Add(new TunedCar(make, model, VIN, horsePower));
            }
            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = carRepository.FindBy(carVIN);

            if(car == null)
            {
                 throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type != nameof(ProfessionalRacer) && type != nameof(StreetRacer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }
            else if (type == nameof(ProfessionalRacer))
            {
                racerRepository.Add(new ProfessionalRacer(car, username));
            }
            else if (type == nameof(StreetRacer))
            {
                racerRepository.Add(new StreetRacer(car, username));
            }
            return string.Format(OutputMessages.SuccessfullyAddedRacer, username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racer1 = racerRepository.FindBy(racerOneUsername);
            IRacer racer2 = racerRepository.FindBy(racerTwoUsername);

            if(racer1 == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racer2 == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }
            return map.StartRace(racer1, racer2);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var racer in racerRepository.Models.OrderByDescending(r => r.DrivingExperience).ThenBy(r => r.Username))
            {
                sb.Append(racer.ToString() + Environment.NewLine);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
