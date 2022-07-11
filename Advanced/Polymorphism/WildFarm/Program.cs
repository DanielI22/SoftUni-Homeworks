using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string command = Console.ReadLine();

            while(command != "End")
            {
                Animal animal = null;

                string[] animalInfo = command.Split(' ');
                string type = animalInfo[0];

                if(type == "Cat")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    
                    animal = new Cat(name, weight, livingRegion, breed);
                    animals.Add(animal);
                }

                else if (type == "Tiger")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];

                    animal = new Tiger(name, weight, livingRegion, breed);
                    animals.Add(animal);

                }

                else if (type == "Owl")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Owl(name, weight, wingSize);
                    animals.Add(animal);

                }

                else if (type == "Hen")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    animal = new Hen(name, weight, wingSize);
                    animals.Add(animal);

                }

                else if (type == "Dog")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    animal = new Dog(name, weight, livingRegion);
                    animals.Add(animal);

                }
                else if (type == "Mouse")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    animal = new Mouse(name, weight, livingRegion);
                    animals.Add(animal);

                }


                string command2 = Console.ReadLine();

                Food currentFood = null;
                string[] fruitInfo = command2.Split(' ');
                string foodType = fruitInfo[0];
                int quantity = int.Parse(fruitInfo[1]);
                
                if(foodType == "Vegetable")
                {
                    currentFood = new Vegetable(quantity);
                }
                else if (foodType == "Fruit")
                {
                    currentFood = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    currentFood = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    currentFood = new Seeds(quantity);
                }

                Console.WriteLine(animal.produceSound());
                animal.feed(currentFood);

                command = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
