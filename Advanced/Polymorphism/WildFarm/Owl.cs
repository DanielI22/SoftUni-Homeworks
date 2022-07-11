using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string produceSound()
        {
            return "Hoot Hoot";
        }

        public override void feed(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.25 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
