using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productPrice = new Dictionary<string, double>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while(command != "buy")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);

                productPrice[name] = price;

                if(productQuantity.ContainsKey(name))
                {
                    productQuantity[name] += quantity;
                }
                else
                {
                    productQuantity[name] = quantity;
                }

                command = Console.ReadLine();
            }

            foreach (var item in productPrice)
            {
                Console.WriteLine($"{item.Key} -> {productPrice[item.Key] *productQuantity[item.Key]:f2}");
            }
        }
    }
}
