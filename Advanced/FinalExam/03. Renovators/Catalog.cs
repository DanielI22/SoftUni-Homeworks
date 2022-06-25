using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; } = new List<Renovator>();
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public int Count => Renovators.Count;
        public string AddRenovator(Renovator renovator)
        {
            if(string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if(NeededRenovators == Renovators.Count)
            {
                return "Renovators are no more needed.";
            }

            if(renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator currentRenovator = Renovators.FirstOrDefault(r => r.Name == name);
            return Renovators.Remove(currentRenovator);
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return Renovators.RemoveAll(r => r.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = Renovators.FirstOrDefault(r => r.Name == name);

            if(renovator == null)
            {
                return null;
            }

            renovator.Hired = true;
            return renovator;
        }

        public 	List<Renovator> PayRenovators(int days)
        {
            List<Renovator> currentList = Renovators.Where(r => r.Days >= days).ToList();
            return currentList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in Renovators.Where(p => p.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
