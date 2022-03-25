using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Plant_Discovery
{
    public class Plant {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; } = new List<int>();

        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Plant> myDic = new Dictionary<string, Plant>();
            for(int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plant = tokens[0];
                int rarity = int.Parse(tokens[1]);

                if(myDic.ContainsKey(plant)) {
                    myDic[plant].Rarity += rarity;
                }
                else
                {
                    myDic[plant] = new Plant(plant, rarity);
                }
            }
            string command = Console.ReadLine();
            while (command != "Exhibition") 
            {
                string[] tokens = command.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];

                if(mainCommand == "Rate")
                {
                    string[] tokens2 = tokens[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string plant = tokens2[0];
                    int rating = int.Parse(tokens2[1]);
                    if(!myDic.ContainsKey(plant)) 
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                    myDic[plant].Rating.Add(rating);
                }
                else if(mainCommand == "Update")
                {
                    string[] tokens2 = tokens[1].Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string plant = tokens2[0];
                    int newRarity = int.Parse(tokens2[1]);
                    if (!myDic.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                    myDic[plant].Rarity = newRarity;
                }
                else if(mainCommand == "Reset")
                {
                    string plant = tokens[1];
                    if (!myDic.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                    myDic[plant].Rating.Clear();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach(var item in myDic)
            {
                if(item.Value.Rating.Count > 0)
                {
                   Console.WriteLine($"- {item.Value.Name}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Rating.Average():f2}");
                }
                else
                {
                    Console.WriteLine($"- {item.Value.Name}; Rarity: {item.Value.Rarity}; Rating: 0.00");
                }
            }
        }
    }
}
