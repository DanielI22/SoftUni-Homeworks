using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var myDic = new Dictionary<string, Dictionary<string, int>>();

            for(int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = tokens[0];

                if(!myDic.ContainsKey(color))
                {
                   myDic.Add(color, new Dictionary<string, int>());
                }

                List<string> clothes = tokens[1].Split(",").ToList();

                foreach (string item in clothes)
                {
                    Dictionary<string, int> currentColorClothes = myDic[color];
                    if (!currentColorClothes.ContainsKey(item))
                    {
                        currentColorClothes[item] = 1;
                    }
                    else
                    {
                        currentColorClothes[item]++;
                    }
                }
            }

            string[] toSearch = Console.ReadLine().Split(' ');
            string colorToSearch = toSearch[0];
            string clothesToSearch = toSearch[1];

            foreach (var item in myDic)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var item2 in item.Value)
                {
                    Console.Write($"* {item2.Key} - {item2.Value}");
                    if(item.Key == colorToSearch && item2.Key == clothesToSearch)
                    {
                        Console.Write(" (found!)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
