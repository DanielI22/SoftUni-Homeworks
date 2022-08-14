using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        private const double defaultPrice = 3.2;
        public BioChemicalWeapon(int destructionLevel) : base(defaultPrice, destructionLevel)
        {
        }
    }
}
