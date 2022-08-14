using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Weapons;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository army;
        private WeaponRepository weapons;
        private string name;
        private double budget;
        private double militaryPower;

        public Planet()
        {
            this.army = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public Planet(string name, double budget) : this()
        {
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower
        {
            get
            {
                double totalAmount = Army.Sum(un => un.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);
                if (Army.Any(u => u.GetType().Name == nameof(AnonymousImpactUnit)))
                {
                    totalAmount *= 1.3;
                }
                if (Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    totalAmount *= 1.45;
                }
                return Math.Round(totalAmount, 3);
            }
            private set 
            {
                militaryPower = value;
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}")
                .AppendLine($"--Budget: {Budget} billion QUID")
                .AppendLine("--Forces: " + (Army.Count > 0 ? $"{string.Join(", ", Army.Select(unit => unit.GetType().Name))}" : "No units"))
                .AppendLine("--Combat equipment: " + (Weapons.Count > 0 ? $"{string.Join(", ", Weapons.Select(w => w.GetType().Name))}" : "No weapons"))
                .AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
