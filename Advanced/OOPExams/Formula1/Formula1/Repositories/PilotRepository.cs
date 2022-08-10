using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> pilots;
        public PilotRepository()
        {
            this.pilots = new HashSet<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return pilots.FirstOrDefault(x => x.FullName.Equals(name));
        }

        public bool Remove(IPilot model)
        {
            return pilots.Remove(model);
        }
    }
}
