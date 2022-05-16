using System;
using System.Text;

namespace Problem_1___Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string command = Console.ReadLine();

            while(command != "Done")
            {
                string[] tokens = command.Split(' ');
                string mainCommand = tokens[0];

                if(mainCommand == "TakeOdd")
                {
                    string newpass = "";
                    for (int i = 0; i < input.Length; i++) { 
                        if(i % 2 != 0)
                        {
                            newpass += input[i];
                        }
                    }
                    input = newpass;
                    Console.WriteLine(input);
                }
                else if(mainCommand == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int length = int.Parse(tokens[2]);

                    string substr = input.Substring(index, length);
                    input = input.Remove(input.IndexOf(substr), length);
                    Console.WriteLine(input);
                }
                else if(mainCommand == "Substitute")
                {
                    string substring = tokens[1];
                    string substi = tokens[2];

                    if(input.Contains(substring))
                    {
                        input = input.Replace(substring, substi);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {input}");
        }
    }
}
