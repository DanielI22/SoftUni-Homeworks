using System;
using System.Collections.Generic;

namespace _3.Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input)
                {
                    string[] tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);

                    Person person = new Person(name, money);
                    people.Add(person);
                }


                string[] input2 = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in input2)
                {
                    string[] tokens = item.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    string productName = tokens[0];
                    decimal cost = decimal.Parse(tokens[1]);

                    Product product = new Product(productName, cost);
                    products.Add(product);
                }


                string command = Console.ReadLine();

                while(command != "END")
                {
                    string[] tokens = command.Split();
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = people.Find(x => x.Name == personName);
                    Product product = products.Find(x => x.Name == productName);

                    person.AddProduct(product);

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    if(person.Products.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
