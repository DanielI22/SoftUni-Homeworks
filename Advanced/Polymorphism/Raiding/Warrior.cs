using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int defaultPower = 100;

        public Warrior(string name) : base(name)
        {
            Power = defaultPower;
        }
    }
}
