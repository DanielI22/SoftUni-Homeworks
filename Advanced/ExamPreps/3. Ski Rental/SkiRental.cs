using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    internal class SkiRental
    {
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SkiRental(string name, int capacity)
        {
            Data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }

        public int Count => Data.Count;

        public void Add(Ski ski)
        {
            if(Data.Count < Capacity)
            {
                Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski currentSki = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return Data.Remove(currentSki);
        }

        public Ski GetNewestSki()
        {
            if(Data.Count == 0)
            {
                return null;
            }
            int maxYear = Data.Max(x => x.Year);
            Ski newestSki = Data.FirstOrDefault(ski => ski.Year == maxYear);
            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski currentSki = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return currentSki;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");

            foreach(Ski ski in Data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
