using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly Dictionary<string, IRace> racesByName;
        public RaceRepository()
        {
            racesByName = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            if (racesByName.ContainsKey(model.Name))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, model.Name));
            }
            racesByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return racesByName.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            if (racesByName.ContainsKey(name))
            {
                return racesByName[name];
            }

            throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, name));
        }

        public bool Remove(IRace model)
        {
            return this.racesByName.Remove(model.Name);
        }
    }
}