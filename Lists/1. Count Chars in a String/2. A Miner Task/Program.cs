using System;
using System.Collections.Generic;

namespace _2._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mydic = new Dictionary<string, int>();
            string command = Console.ReadLine();
            while(command != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (mydic.ContainsKey(command))
                {
                    mydic[command] += quantity;
                }
                else
                {
                    mydic[command] = quantity;
                }
                command = Console.ReadLine();
            }
            foreach (var item in mydic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
