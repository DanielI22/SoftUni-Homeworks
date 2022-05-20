using System;
using System.Collections;
using System.Linq;

namespace _2._Basic_Queue_Operations
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
            Queue myStack = new Queue();

            for (int i = 0; i < n; i++)
            {
                myStack.Enqueue(inputNum[i]);
            }

            for (int i = 0; i < s; i++)
            {
                myStack.Dequeue();
            }

            if (myStack.Count == 0)
            {
                Console.WriteLine(0);
            }

            else if (myStack.Contains(x))
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
                Console.WriteLine(min);
            }
        }
    }
}
