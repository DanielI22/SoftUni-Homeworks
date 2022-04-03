using System;
using System.Collections.Generic;

namespace FinalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while(command != "Done")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCom = tokens[0];

                if(mainCom == "Change")
                {
                    char c = char.Parse(tokens[1]);
                    char replacement = char.Parse(tokens[2]);
                    input = input.Replace(c, replacement);
                    Console.WriteLine(input);
                }
                else if(mainCom == "Includes")
                {
                    string subString = tokens[1];
                    if (input.Contains(subString))
                    {
                        Console.WriteLine("True");
                    }
                    else 
                    { 
                        Console.WriteLine("False"); 
                    }
                }
                else if(mainCom == "End")
                {
                    string subString = tokens[1];
                    if (input.EndsWith(subString))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (mainCom == "Uppercase")
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (mainCom == "FindIndex")
                {
                    char c = char.Parse(tokens[1]);
                    int index = input.IndexOf(c);
                    Console.WriteLine(index);
                }
                else if (mainCom == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int count = int.Parse(tokens[2]);
                    input = input.Substring(startIndex, count);
                    Console.WriteLine(input);
                }
                command = Console.ReadLine();
            }
        }
    }
}
