
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new HashSet<IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)cars;

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return cars.FirstOrDefault(n => n.Model.Equals(name));
        }

        public bool Remove(IFormulaOneCar model)
        {
            return cars.Remove(model);
        }
    }
}
