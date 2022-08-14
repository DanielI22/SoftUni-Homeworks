using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private HashSet<IRacer> racers;

        public RacerRepository()
        {
            racers = new HashSet<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => racers;


        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            racers.Add(racer);
        }

        public IRacer FindBy(string username) => racers.FirstOrDefault(r => r.Username == username);

        public bool Remove(IRacer racer) => racers.Remove(racer);
    }
}
