using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIteratorExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            ListyIterator<string> myListy;
            string[] tokens = command.Split(' ', 2);

            if(tokens.Length == 1)
            {
                myListy = new ListyIterator<string>();
            }
            else
            {
                myListy = new ListyIterator<string>(tokens[1].Split(' '));
            }

            command = Console.ReadLine();
            while (command != "END")
            {
                if(command == "HasNext")
                {
                    Console.WriteLine(myListy.HasNext());
                }
                else if(command == "Move")
                {
                    Console.WriteLine(myListy.Move());
                }
                else if(command == "Print")
                {
                    try
                    {
                        myListy.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    try
                    {
                        myListy.PrintAll();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}
