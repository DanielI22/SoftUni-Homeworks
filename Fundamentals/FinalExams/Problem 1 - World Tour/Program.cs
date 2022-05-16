using System;

namespace Problem_1___World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string finalString = Console.ReadLine();
            string input = Console.ReadLine();
            while(input != "Travel")
            {
                string[] tokens = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if(command == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    string adds = tokens[2];

                    if(index >= 0 && index < finalString.Length)
                    {
                        finalString = finalString.Insert(index, adds);
                    }
                    Console.WriteLine(finalString);
                }
                else if(command == "Remove Stop")
                {
                    int startindex = int.Parse(tokens[1]);
                    int endindex = int.Parse(tokens[2]);

                    if(startindex >= 0 && startindex < finalString.Length && endindex >= 0 && endindex < finalString.Length)
                    {
                        finalString = finalString.Remove(startindex, endindex-startindex + 1);
                    }
                    Console.WriteLine(finalString);
                }
                else if(command == "Switch")
                {
                    string oldString = tokens[1];
                    string newString = tokens[2];
                    finalString = finalString.Replace(oldString, newString);
                    Console.WriteLine(finalString);
                } 

                input = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {finalString}");
        }
    }
}
