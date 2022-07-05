using System;

namespace _4.PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = null;
                string command = Console.ReadLine();

                while (command != "END")
                {

                    string[] tokens = command.Split(' ');
                    string ingredient = tokens[0];

                    if(ingredient == "Pizza")
                    {
                        string name = tokens[1];
                        pizza = new Pizza(name);
                    }
                    else if (ingredient == "Dough")
                    {
                        string flour = tokens[1];
                        string bakingtech = tokens[2];
                        double weight = double.Parse(tokens[3]);
                        Dough dough = new Dough(flour, bakingtech, weight);
                        pizza.Dough = dough;
                    }
                    else if(ingredient == "Topping")
                    {
                        string type = tokens[1];
                        double weight = double.Parse(tokens[2]);
                        Topping topping = new Topping(type, weight);
                        pizza.AddTopping(topping);
                    }
                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
            }
           catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
