using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            MilitaryUnit unitToAdd;
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(SpaceForces) && unitTypeName != nameof(AnonymousImpactUnit))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (unitTypeName == nameof(StormTroopers))
            {
                if(planet.Army.Any(unit => unit.GetType().Name == nameof(StormTroopers)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
                unitToAdd = new StormTroopers();
                planet.Spend(unitToAdd.Cost);
                planet.AddUnit(unitToAdd);
            }

            else if (unitTypeName == nameof(SpaceForces))
            {
                if (planet.Army.Any(unit => unit.GetType().Name == nameof(SpaceForces)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
                unitToAdd = new SpaceForces();
                planet.Spend(unitToAdd.Cost);
                planet.AddUnit(unitToAdd);
            }

            else if (unitTypeName == nameof(AnonymousImpactUnit))
            {
                if (planet.Army.Any(unit => unit.GetType().Name == nameof(AnonymousImpactUnit)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
                }
                unitToAdd = new AnonymousImpactUnit();
                planet.Spend(unitToAdd.Cost);
                planet.AddUnit(unitToAdd);
            }

            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            Weapon weaponToAdd;
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (weaponTypeName != nameof(BioChemicalWeapon) && weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                if (planet.Weapons.Any(weapon => weapon.GetType().Name == nameof(BioChemicalWeapon)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
                weaponToAdd = new BioChemicalWeapon(destructionLevel);
                planet.Spend(weaponToAdd.Price);
                planet.AddWeapon(weaponToAdd);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                if (planet.Weapons.Any(weapon => weapon.GetType().Name == nameof(NuclearWeapon)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
                weaponToAdd = new NuclearWeapon(destructionLevel);
                planet.Spend(weaponToAdd.Price);
                planet.AddWeapon(weaponToAdd);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                if (planet.Weapons.Any(weapon => weapon.GetType().Name == nameof(SpaceMissiles)))
                {
                    throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
                }
                weaponToAdd = new SpaceMissiles(destructionLevel);
                planet.Spend(weaponToAdd.Price);
                planet.AddWeapon(weaponToAdd);
            }

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if(planets.Models.Any(planet => planet.Name == name))
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }
            planets.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(pl => pl.MilitaryPower).ThenBy(pl => pl.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);
            IPlanet winner = null;
            IPlanet loser = null;

            if(planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if (planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)) 
                    && !planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winner = planet1;
                    loser = planet2;
                }
                else if (!planet1.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon))
                    && planet2.Weapons.Any(w => w.GetType().Name == nameof(NuclearWeapon)))
                {
                    winner = planet2;
                    loser = planet1;
                }
                else
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }
            else if(planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                loser = planet2;
            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                loser = planet1;
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(unit => unit.Cost));
            winner.Profit(loser.Weapons.Sum(w => w.Price));
            planets.RemoveItem(loser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
