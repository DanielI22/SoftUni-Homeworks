using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animal = Console.ReadLine();

            while(animal != "Beast!")
            {
                try
                {
                    string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (animal == "Cat")
                    {
                        animals.Add(new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]));
                    }
                    else if(animal == "Dog")
                    {
                        animals.Add(new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]));
                    }
                    else if (animal == "Frog")
                    {
                        animals.Add(new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]));
                    }
                    else if (animal == "Tomcat")
                    {
                        animals.Add(new Tomcat(tokens[0], int.Parse(tokens[1])));
                    }
                    else if (animal == "Kitten")
                    {
                        animals.Add(new Kitten(tokens[0], int.Parse(tokens[1])));
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                 animal = Console.ReadLine();

            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
