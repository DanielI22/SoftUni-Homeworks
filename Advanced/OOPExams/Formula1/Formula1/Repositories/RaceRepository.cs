﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> races;

        public RaceRepository()
        {
            races = new HashSet<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return races.FirstOrDefault(r => r.RaceName.Equals(name));
        }

        public bool Remove(IRace model)
        {
            return races.Remove(model);
        }
    }
}
