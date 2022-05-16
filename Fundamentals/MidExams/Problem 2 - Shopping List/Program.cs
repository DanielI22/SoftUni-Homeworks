using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2___Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> foodList = Console.ReadLine().Split('!').ToList();

            string command = Console.ReadLine();

            while(command != "Go Shopping!")
            {
                string[] tokens = command.Split();
                string mainCommand = tokens[0];
                string item = tokens[1];

                if(mainCommand == "Urgent")
                {
                    if (!foodList.Contains(item))
                    {
                        foodList.Insert(0, item);
                    }
                }
                else if(mainCommand == "Unnecessary")
                {
                    if (foodList.Contains(item))
                    {
                        foodList.Remove(item);
                    }
                }
                else if (mainCommand == "Correct")
                {
                    string newItem = tokens[2];
                    if (foodList.Contains(item))
                    {
                       int indexOld = foodList.IndexOf(item);
                       foodList.Remove(item);
                       foodList.Insert(indexOld, newItem);
                    }
                }
                else if (mainCommand == "Rearrange")
                {
                    if(foodList.Contains(item))
                    {
                       foodList.Remove(item);
                       foodList.Add(item);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", foodList));
        }
    }
}
