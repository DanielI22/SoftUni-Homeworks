﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> equipments;

        public EquipmentRepository()
        {
            equipments = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => equipments;

        public void Add(IEquipment equipment) => equipments.Add(equipment);

        public IEquipment FindByType(string type)
        {
            return equipments.FirstOrDefault(eq => eq.GetType().Name == type);
        }

        public bool Remove(IEquipment equipment) => equipments.Remove(equipment);
    }
}
