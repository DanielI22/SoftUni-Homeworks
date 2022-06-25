using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(input1);
            Queue<int> greyTiles = new Queue<int>(input2);

            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                {"Sink", 0},
                {"Oven", 0},
                {"Countertop", 0},
                {"Wall", 0},
                {"Floor", 0}
            };

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();

                int finalTile = 0;
                if (currentWhite == currentGrey)
                {
                    finalTile = currentGrey + currentWhite;
                    if (finalTile == 40)
                    {
                        locations["Sink"]++;
                    }
                    else if (finalTile == 50)
                    {
                        locations["Oven"]++;
                    }
                    else if (finalTile == 60)
                    {
                        locations["Countertop"]++;
                    }
                    else if (finalTile == 70)
                    {
                        locations["Wall"]++;
                    }
                    else
                    {
                        locations["Floor"]++;
                    }
                }
                else
                {
                    whiteTiles.Push(currentWhite/2);
                    greyTiles.Enqueue(currentGrey);
                }
            }

            if(whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var item in locations.Where(p => p.Value != 0).OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
