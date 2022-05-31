using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = tokens[0];
                string secCommand = tokens[1];
                string arg = tokens[2];

                if (mainCommand == "Remove")
                {
                    switch (secCommand)
                    {
                        case "StartsWith":
                            people.RemoveAll(x => x.StartsWith(arg));
                            break;
                        case "EndsWith":
                            people.RemoveAll(x => x.EndsWith(arg));
                            break;
                        case "Length":
                            people.RemoveAll(x => x.Length == int.Parse(arg));
                            break;
                    }
                }
                else if (mainCommand == "Double")
                {
                    switch (secCommand)
                    {
                        case "StartsWith":
                            people = people.Where(x => x.StartsWith(arg)).SelectMany(x => Enumerable.Repeat(x, 2)).ToList();
                            break;
                        case "EndsWith":
                            people = people.Where(x => x.EndsWith(arg)).SelectMany(x => Enumerable.Repeat(x, 2)).ToList();
                            break;
                        case "Length":
                            people = people.Where(x => x.Length == int.Parse(arg)).SelectMany(x => Enumerable.Repeat(x, 2)).ToList();
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            else
            {
                Console.Write(string.Join(", ", people));
                Console.Write(" are going to the party!");
            }
        }
    }
}
