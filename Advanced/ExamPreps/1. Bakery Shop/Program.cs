using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPreps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] input1 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] input2 = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(input1);
            Stack<double> flour = new Stack<double>(input2);

            Dictionary<string, int> products = new Dictionary<string, int>();

            while (water.Count > 0 && flour.Count > 0)
            {
                double currentWater = water.Dequeue();
                double currentFlour = flour.Pop();
                double sum = currentWater + currentFlour;
                double waterRatio = currentWater * 100 / sum;
                double flourRatio = 100 - waterRatio;

                if (waterRatio == 50 && flourRatio == 50)
                {
                    if (products.ContainsKey("Croissant"))
                    {
                        products["Croissant"]++;
                    }
                    else
                    {
                        products["Croissant"] = 1;
                    }
                }
                else if (waterRatio == 40 && flourRatio == 60)
                {
                    if (products.ContainsKey("Muffin"))
                    {
                        products["Muffin"]++;
                    }
                    else
                    {
                        products["Muffin"] = 1;
                    }

                }
                else if (waterRatio == 30 && flourRatio == 70)
                {
                    if (products.ContainsKey("Baguette"))
                    {
                        products["Baguette"]++;
                    }
                    else
                    {
                        products["Baguette"] = 1;
                    }

                }
                else if (waterRatio == 20 && flourRatio == 80)
                {
                    if (products.ContainsKey("Bagel"))
                    {
                        products["Bagel"]++;
                    }
                    else
                    {
                        products["Bagel"] = 1;
                    }

                }
                else
                {
                    double excessiveFlour = currentFlour - currentWater;
                    flour.Push(excessiveFlour);
                    if (products.ContainsKey("Croissant"))
                    {
                        products["Croissant"]++;
                    }
                    else
                    {
                        products["Croissant"] = 1;
                    }
                }
            }


            foreach (var item in products.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
    }
}
