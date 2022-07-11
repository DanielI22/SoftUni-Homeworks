using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override string produceSound()
        {
            return "ROAR!!!";
        }

        public override void feed(Food food)
        {
            if (food is Meat)
            {
                FoodEaten += food.Quantity;
                Weight += 1 * food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
