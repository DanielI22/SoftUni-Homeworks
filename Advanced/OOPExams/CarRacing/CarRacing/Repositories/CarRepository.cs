using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private HashSet<ICar> cars;

        public CarRepository()
        {
            cars = new HashSet<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => cars;

        public void Add(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            cars.Add(car);
        }

        public ICar FindBy(string vin) => cars.FirstOrDefault(c => c.VIN == vin);

        public bool Remove(ICar car) => cars.Remove(car);
    }
}
