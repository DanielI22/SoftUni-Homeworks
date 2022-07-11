using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string produceSound()
        {
            return "Meow";
        }

        public override void feed(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 0.3*food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
