using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings { get; set; } = new List<Topping>();

        public Pizza(string name)
        {
            Name = name;
        }

        public Dough Dough { get; set; }

        public string Name 
        { 
            get { return name; }
            set 
            { 
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value; 
            }
        }

        public IReadOnlyCollection<Topping> Toppings { get { return toppings.AsReadOnly(); } }
        public void AddTopping(Topping topping)
        {
            if(Toppings.Count == 10)
            {
               throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }


        public double CalculateCalories()
        {
            double calories = Dough.Calories;
            foreach (var item in toppings)
            {
                calories += item.Calories;
            }

            return calories;
        }
    }
}
