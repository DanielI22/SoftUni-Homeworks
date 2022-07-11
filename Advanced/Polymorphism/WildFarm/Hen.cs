using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string produceSound()
        {
            return "Cluck";
        }

        public override void feed(Food food)
        {
            FoodEaten += food.Quantity;
            Weight += 0.35 * food.Quantity;
        }
    }
}
