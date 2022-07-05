using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            products = new List<Product>();
            Name = name;
            Money = money;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Products { get { return products.AsReadOnly(); } }

        public void AddProduct(Product product)
        {
            if(money >= product.Cost)
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                money -= product.Cost;
                products.Add(product);
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
