using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(input1);
            Stack<int> freshness = new Stack<int>(input2);

            SortedDictionary<string, int> products = new SortedDictionary<string, int>()
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0}
            };


            while(ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngr = ingredients.Dequeue();

                if(currentIngr==0)
                {
                    continue;
                }

                int currentFreshness = freshness.Pop();
                int totalFreshness = currentIngr * currentFreshness;



                if(totalFreshness == 150)
                {
                    products["Dipping sauce"]++;
                }
                else if (totalFreshness == 250)
                {
                    products["Green salad"]++;
                }
                else if (totalFreshness == 300)
                {
                    products["Chocolate cake"]++;
                }
                else if (totalFreshness == 400)
                {
                    products["Lobster"]++;
                }
                else
                {
                    ingredients.Enqueue(currentIngr + 5);
                }
            }

            if(products.Where(p => p.Value != 0).Count() == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if(ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var item in products.Where(p=>p.Value!=0))
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
