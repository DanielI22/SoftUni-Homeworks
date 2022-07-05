using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Topping
    {
        private static Dictionary<string, double> allowedTypes = new Dictionary<string, double>()
        {
            {"meat", 1.2},
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9},
        };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            CaloriesPerGram = 2 * allowedTypes[Type.ToLower()];
            Calories = CaloriesPerGram * Weight;
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (!allowedTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double CaloriesPerGram { get; }

        public double Calories { get; }
    }
}
