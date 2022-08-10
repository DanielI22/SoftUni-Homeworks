using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Utilities.Messages;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private readonly ICollection<IEquipment> equipments;
        private readonly ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
            Name = name;
            Capacity = capacity;
        }

        public string Name 
        {
            get => name;
            private set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => equipments.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if(athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            equipments.Add(equipment);
        }

        public void Exercise()
        {
            foreach(IAthlete athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:")
                .AppendLine(athletes.Count == 0 ? "Athletes: No athletes" : $"Athletes: {string.Join(", ", athletes.Select(a => a.FullName))}")
                .AppendLine($"Equipment total count: {equipments.Count}")
                .AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => athletes.Remove(athlete);
    }
}
