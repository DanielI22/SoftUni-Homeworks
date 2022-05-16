using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Legendary_Farming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mydic = new Dictionary<string, int>();
            mydic["motes"] = 0;
            mydic["shards"] = 0;
            mydic["fragments"] = 0;
            string itemObtained = "";
            while (true)
            {
                bool breakbool = false;
                string[] tokens = Console.ReadLine().Split();
                for (int i = 1; i < tokens.Length; i += 2)
                {
                    if (mydic.ContainsKey(tokens[i].ToLower()))
                    {
                        mydic[tokens[i].ToLower()] += int.Parse(tokens[i - 1]);
                        if (mydic["motes"] >= 250)
                        {
                            itemObtained = "Dragonwrath";
                            mydic["motes"] -= 250;
                            breakbool = true;
                            break;
                        }
                        if (mydic["fragments"] >= 250)
                        {
                            itemObtained = "Valanyr";
                            mydic["fragments"] -= 250;
                            breakbool = true;
                            break;
                        }
                        if (mydic["shards"] >= 250)
                        {
                            itemObtained = "Shadowmourne";
                            mydic["shards"] -= 250;
                            breakbool = true;
                            break;
                        }
                    }
                    else
                    {
                        mydic[tokens[i].ToLower()] = int.Parse(tokens[i - 1]);
                    }
                }
                if (breakbool) break;
            }
            Console.WriteLine($"{itemObtained} obtained!");
            Console.WriteLine($"shards: {mydic["shards"]}");
            Console.WriteLine($"motes: {mydic["motes"]}");
            Console.WriteLine($"fragments: {mydic["fragments"]}");
            foreach (var item in mydic)
            {
                if(item.Key != "shards" && item.Key != "motes" && item.Key!="fragments")
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
