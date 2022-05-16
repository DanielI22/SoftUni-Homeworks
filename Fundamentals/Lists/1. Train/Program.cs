using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> n = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int maxCap = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] comm = command.Split();

                if (comm[0] == "Add")
                {
                    int com = int.Parse(comm[1]);
                    n.Add(com);
                }

                else
                {
                    int dig = int.Parse(comm[0]);
                    for (int i = 0; i < n.Count; i++)
                    {
                        if (dig <= maxCap - n[i]) {
                            n[i] += dig;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", n));
        }
    }
}
