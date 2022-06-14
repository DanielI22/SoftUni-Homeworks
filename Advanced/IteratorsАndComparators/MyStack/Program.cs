using System;

namespace MyStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();
            string command = Console.ReadLine();

            while(command != "END")
            {
                string[] tokens = command.Split(' ', 2);
                if(tokens[0] == "Push")
                {
                    myStack.Push(tokens[1].Split(", "));
                }
                else if(tokens[0] == "Pop")
                {
                    if(myStack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                    }
                    else
                    {
                       myStack.Pop();
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
