using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly Dictionary<string, ICar> carsByModel;

        public CarRepository()
        {
            carsByModel = new Dictionary<string, ICar>();
        }

        public void Add(ICar model)
        {
            if (carsByModel.ContainsKey(model.Model))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CarExists, model.Model));
            }
            carsByModel.Add(model.Model, model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return carsByModel.Values.ToList();
        }

        public ICar GetByName(string name)
        {
            if (carsByModel.ContainsKey(name))
            {
                return carsByModel[name];
            }
            throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, name));
        }

        public bool Remove(ICar model)
        {
            return this.carsByModel.Remove(model.Model);
        }
    }
}
