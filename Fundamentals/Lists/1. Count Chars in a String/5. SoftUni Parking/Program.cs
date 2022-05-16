using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> mydic = new Dictionary<string, string>();
            for(int i = 0; i<n; i++)
            {
                string[] command = Console.ReadLine().Split();
                
                if(command[0] == "register")
                {
                    string user = command[1];
                    string license = command[2];

                    if(mydic.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {license}");
                    }
                    else
                    {
                        mydic[user] = license;
                        Console.WriteLine($"{user} registered {license} successfully");
                    }
                }
                else if(command[0] == "unregister")
                {
                    string user = command[1];
                    if (!mydic.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");
                    }
                    else
                    {
                        mydic.Remove(user);
                        Console.WriteLine($"{user} unregistered successfully");
                    }
                }
            }
            foreach (var item in mydic)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
