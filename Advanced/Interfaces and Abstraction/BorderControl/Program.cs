using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<IBuyer> list = new List<IBuyer>();

            for(int i = 0; i < N; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');

                if(tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birthdate);
                    list.Add(citizen);
                }
                else if(tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);
                    list.Add(rebel);
                }
            }

            string command = Console.ReadLine();
            HashSet<IBuyer> buyers = new HashSet<IBuyer>();
            while(command != "End")
            {
                IBuyer buyer = list.FirstOrDefault(x => x.Name == command);
                if(buyer != null)
                {
                    buyer.BuyFood();
                    buyers.Add(buyer);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(buyers.Sum(x => x.Food));

            //string command = Console.ReadLine();
            //List<IBorn> population = new List<IBorn>();
            //while(command != "End")
            //{
            //    string[] tokens = command.Split();
            //    string type = tokens[0];


            //    if(type == "Citizen")
            //    {
            //        string name = tokens[1];
            //        int age = int.Parse(tokens[2]);
            //        string id = tokens[3];
            //        string birthdate = tokens[4];

            //        Citizen citizen = new Citizen(name, age, id, birthdate);
            //        population.Add(citizen);
            //    }

            //    else if(type == "Robot")
            //    {
            //        string model = tokens[1];
            //        string id = tokens[2];

            //        Robot robot = new Robot(model, id);
            //    }
            //    else if(type == "Pet")
            //    {
            //        string name = tokens[1];
            //        string birthdate = tokens[2];

            //        Pet pet = new Pet(name, birthdate);
            //        population.Add(pet);
            //    }
            //    command = Console.ReadLine();
            //}

            //string year = Console.ReadLine();

            //List<IBorn> chosen = new List<IBorn>();

            //foreach (IBorn item in population)
            //{
            //    if (item.Birthdate.Split('/')[2] == year)
            //    {
            //        chosen.Add(item);
            //    }
            //}

            //foreach (var item in chosen)
            //{
            //    Console.WriteLine(item.Birthdate);
            //}
        }
    }
}
