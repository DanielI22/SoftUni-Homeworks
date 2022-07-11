using System;

namespace ExplicitInterfaces
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] tokens = command.Split(' ');
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson citizen = new Citizen(name, country, age);
                IResident citizen2 = new Citizen(name, country, age);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizen2.GetName());
                command = Console.ReadLine();
            }
        }
    }
}
