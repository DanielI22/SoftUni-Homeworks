using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;
            while(pokemons.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                int indexValue;

                if (index < 0)
                {
                    index = 0;
                    sum += pokemons[index];
                    indexValue = pokemons[index];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons.Last());
                }

                else if(index >= pokemons.Count)
                {
                    index = pokemons.Count - 1;
                    sum += pokemons[index];
                    indexValue = pokemons[index];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons[0]);
                }
                else
                {
                    sum += pokemons[index];
                    indexValue = pokemons[index];
                    pokemons.RemoveAt(index);
                }

                for (int item = 0; item < pokemons.Count; item++)
                {
                    if(pokemons[item] <= indexValue)
                    {
                        pokemons[item] += indexValue;
                    }
                    else
                    {
                        pokemons[item] -= indexValue;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
