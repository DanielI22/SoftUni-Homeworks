using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Dough
    {
        private static Dictionary<string, double> allowedTypes = new Dictionary<string, double>()
        {
            {"white", 1.5},
            {"wholegrain", 1.0},
            {"crispy", 0.9},
            {"chewy", 1.1},
            {"homemade", 1.0}
        }; 

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double calories;
        private double modifier;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            Modifier = allowedTypes[FlourType.ToLower()] * allowedTypes[BakingTechnique.ToLower()];
            CaloriesPerGram = 2 * Modifier;
            Calories = CaloriesPerGram *  Weight;
        }

        public string FlourType { 
            get 
            { 
                return flourType;
            } 
            set 
            { 
                if(!allowedTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value; 
            } 
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (!allowedTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
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
                if(value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double CaloriesPerGram { get; }

        public double Modifier
        {
            get { return modifier; }
            private set
            {
                modifier = value;
            }
        }
        public double Calories
        {
            get { return calories; }
            private set
            {
                calories = value;
            }
        }
    }
}
