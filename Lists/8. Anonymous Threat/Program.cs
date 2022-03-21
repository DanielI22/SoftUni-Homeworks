using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();
            while(command != "3:1")
            {
                string[] tokens = command.Split();
                string mainCommand = tokens[0];

                if(mainCommand == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if(startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if(endIndex >= inputLine.Count)
                    {
                        endIndex = inputLine.Count - 1;
                    }
                    for(int i = startIndex + 1; i <= endIndex; i++)
                    {
                        inputLine[startIndex] += inputLine[i];
                        inputLine.RemoveAt(i--);
                        endIndex--;
                    }
                }
                else if(mainCommand == "divide")
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);

                    int charsPerEl = inputLine[index].Length / partitions;
                    for(int i = 0; i < partitions; i++)
                    {
                        string currString = inputLine[index].Substring(0, charsPerEl);
                        inputLine[index] = inputLine[index].Remove(0, charsPerEl);
                        inputLine.Insert(index + 1 + i, currString);
                    }
                    inputLine[index + partitions] += inputLine[index];
                    inputLine.RemoveAt(index);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", inputLine));
        }
    }
}
