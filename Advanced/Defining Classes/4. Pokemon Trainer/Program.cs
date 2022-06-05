using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Trainer> trainers = new List<Trainer>();
            
            while(command != "Tournament")
            {
                string[] input = command.Split(' ');
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if(trainers.Any(trainer => trainer.Name == trainerName))
                {
                    trainers.Where(trainer => trainer.Name == trainerName).First().Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

                else
                {
                    trainers.Add(new Trainer(trainerName));
                    trainers.Where(trainer => trainer.Name == trainerName).First().Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
                

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while(command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if(trainer.Pokemons.Any(pokemon => pokemon.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i<trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if(trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(trainer => trainer.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
