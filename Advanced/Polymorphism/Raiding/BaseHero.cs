using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        public string Name { get; set; }
        public int Power { get; set; }

        protected BaseHero(string name)
        {
            Name = name;
        }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
