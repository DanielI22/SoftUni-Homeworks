using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;
        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);
            if(pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            if(car == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = raceRepository.FindByName(raceName);
            IPilot pilot = pilotRepository.FindByName(pilotFullName);

            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            if(pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if(type != nameof(Williams) && type != nameof(Ferrari))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            if(type == nameof(Ferrari))
            {
                carRepository.Add(new Ferrari(model, horsepower, engineDisplacement));
            }
            else if(type == nameof(Williams))
            {
                carRepository.Add(new Williams(model, horsepower, engineDisplacement));
            }
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if(pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            pilotRepository.Add(new Pilot(fullName));
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            raceRepository.Add(new Race(raceName, numberOfLaps));
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPilot pilot in pilotRepository.Models.OrderByDescending(pilot => pilot.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IRace race in raceRepository.Models.Where(race => race.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            IRace race = raceRepository.FindByName(raceName);
            if(race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if(race.Pilots.Count() < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if(race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> pilots = race.Pilots.OrderByDescending(pilot => pilot.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            pilotRepository.FindByName(pilots.First().FullName).WinRace();
            race.TookPlace = true;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {pilots.First().FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race.")
                .AppendLine($"Pilot {pilots[2].FullName} is third in the {raceName} race.");

            return sb.ToString().Trim();
        }
    }
}
