using Gym.Core.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Equipment;
using System.Linq;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            if(athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            else if(athleteType == nameof(Boxer))
            {
                if(gym.GetType().Name == nameof(BoxingGym))
                {
                    gym.AddAthlete(new Boxer(athleteName, motivation, numberOfMedals));
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                }
            }
            else if(athleteType == nameof(Weightlifter))
            {
                if (gym.GetType().Name == nameof(WeightliftingGym))
                {
                    gym.AddAthlete(new Weightlifter(athleteName, motivation, numberOfMedals));
                    return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
                }
            }
                return OutputMessages.InappropriateGym;
        }

        public string AddEquipment(string equipmentType)
        {
            if(equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            
            else if (equipmentType == nameof(BoxingGloves))
            {
                equipment.Add(new BoxingGloves());
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment.Add(new Kettlebell());
            }
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if(gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            else if(gymType == nameof(BoxingGym))
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if(gymType == nameof(WeightliftingGym))
            {
                gyms.Add(new WeightliftingGym(gymName));
            }

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            IEquipment currEquipment = equipment.FindByType(equipmentType);

            if (currEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            equipment.Remove(currEquipment);
            gym.AddEquipment(currEquipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            int count = 0;
            foreach(var athlete in gym.Athletes)
            {
                athlete.Exercise();
                count++;
            }
            return string.Format(OutputMessages.AthleteExercise, count);
        }
    }
}
