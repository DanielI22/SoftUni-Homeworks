using System;
using System.Collections.Generic;

namespace _03._Messages_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> userSent = new Dictionary<string, int>();
            Dictionary<string, int> userReceived = new Dictionary<string, int>();

            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while(command != "Statistics")
            {
                string[] tokens = command.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string mainCom = tokens[0];

                if(mainCom == "Add")
                {
                    string username = tokens[1];
                    int sent = int.Parse(tokens[2]);
                    int recieved = int.Parse(tokens[3]);

                    if (!userSent.ContainsKey(username)) 
                    {
                        userSent.Add(username, sent);
                        userReceived.Add(username, recieved);
                    }
                }
                else if(mainCom == "Message")
                {
                    string sender = tokens[1];
                    string recieiver = tokens[2];

                    if (userSent.ContainsKey(sender) && userSent.ContainsKey(recieiver))
                    {
                        userSent[sender]++;
                        userReceived[recieiver]++;
                        if(userSent[sender] + userReceived[sender] == n)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            userSent.Remove(sender);
                            userReceived.Remove(sender);
                        }
                        if(userSent[recieiver] + userReceived[recieiver] == n)
                        {
                            Console.WriteLine($"{recieiver} reached the capacity!");
                            userSent.Remove(recieiver);
                            userReceived.Remove(recieiver);
                        }
                    }
                }
                else if(mainCom == "Empty")
                {
                    string username = tokens[1];
                    if(userSent.ContainsKey(username))
                    {
                        userSent.Remove(username);
                        userReceived.Remove(username);
                    }
                    if(username == "All")
                    {
                        userSent.Clear();
                        userReceived.Clear();
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {userSent.Count}");
            foreach (var item in userSent)
            {
                Console.WriteLine($"{item.Key} - {item.Value + userReceived[item.Key]}");
            }

        }
    }
}
