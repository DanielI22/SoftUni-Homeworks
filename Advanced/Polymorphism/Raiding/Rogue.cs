using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int defaultPower = 80;

        public Rogue(string name) : base(name)
        {
            Power = defaultPower;
        }
    }
}
