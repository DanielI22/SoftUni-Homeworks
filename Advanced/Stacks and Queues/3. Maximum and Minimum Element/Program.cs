using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> myStack = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (command[0] == 1)
                {
                    myStack.Push(command[1]);
                }

                else if (command[0] == 2)
                {
                    myStack.Pop();
                }

                else if (command[0] == 4)
                {
                    if (myStack.Count > 0)
                    {
                        int min = (int)myStack.Peek();
                        foreach (int item in myStack)
                        {
                            if (item < min) min = item;
                        }
                        Console.WriteLine(min);
                    }
                }

                else if (command[0] == 3)
                {
                    if (myStack.Count > 0)
                    {
                        int max = (int)myStack.Peek();
                        foreach (int item in myStack)
                        {
                            if (item > max) max = item;
                        }
                        Console.WriteLine(max);
                    }
                }
            }

            Console.WriteLine(String.Join(", ", myStack.ToArray()));
        }
    }
}
