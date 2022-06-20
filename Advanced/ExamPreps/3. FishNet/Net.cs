using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; } 
        public string Material { get; set; }
        public int Capacity { get; set; }

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish=new List<Fish>();
        }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if(string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight <= 0 || fish.Length <=0)
            {
                return "Invalid fish.";
            }

            if(this.Count >= Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if(Fish.RemoveAll(fish => fish.Weight == weight) > 0)
            {
                return true;
            }
            return false;
        }

        public Fish GetFish(string fishType)
        {
            Fish currentFish = Fish.FirstOrDefault(fish => fish.FishType == fishType);
            return currentFish;
        }

        public Fish GetBiggestFish()
        {
            double maxLength = Fish.Max(fish => fish.Length);
            return Fish.FirstOrDefault(fish => fish.Length == maxLength);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(fish => fish.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
