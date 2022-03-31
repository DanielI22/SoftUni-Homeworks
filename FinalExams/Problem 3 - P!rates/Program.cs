using System;
using System.Collections.Generic;

namespace Problem_3___P_rates
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, int> townPeople = new Dictionary<string, int>();
            Dictionary<string, int> townGold = new Dictionary<string, int>();
            while (command != "Sail")
            {
                string[] tokens = command.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string city = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);

                if (!townPeople.ContainsKey(city))
                {
                    townPeople.Add(city, population);
                    townGold.Add(city, gold);
                }
                else
                {
                    townPeople[city] += population;
                    townGold[city] += gold;
                }
                command = Console.ReadLine();
            }

            string command2 = Console.ReadLine();

            while (command2 != "End")
            {
                string[] tokens = command2.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                string town = tokens[1];

                if (mainCommand == "Plunder")
                {
                    int people = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    townPeople[town] -= people;
                    townGold[town] -= gold;
                    if (townPeople[town] <= 0 || townGold[town] <= 0)
                    {
                        townPeople.Remove(town);
                        townGold.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (mainCommand == "Prosper")
                {
                    int gold = int.Parse(tokens[2]);
                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        command2 = Console.ReadLine();
                        continue;
                    }
                    townGold[town] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {townGold[town]} gold.");
                }
                command2= Console.ReadLine();
            }
            if (townPeople.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {townPeople.Count} wealthy settlements to go to:");
                foreach (var town in townPeople)
                {
                    Console.WriteLine($"{town.Key} -> Population: {town.Value} citizens, Gold: {townGold[town.Key]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
