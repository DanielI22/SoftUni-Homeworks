using System;
using System.Collections;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(inputArray[0]);
            int s = int.Parse(inputArray[1]);
            int x = int.Parse(inputArray[2]);

            int[] inputNum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack myStack = new Stack();

            for(int i = 0; i < n; i++)
            {
                myStack.Push(inputNum[i]);
            }

            for(int i = 0; i < s; i++)
            {
                myStack.Pop();
            }

            if(myStack.Count == 0)
            {
                Console.WriteLine(0);
            }

            else if(myStack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else
            {
                int min = (int)myStack.Peek();
                foreach (int item in myStack)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }
                Console.WriteLine(myStack);
            }
        }
    }
}
