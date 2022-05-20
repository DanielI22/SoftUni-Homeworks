using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxCap = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(n);
            int racks = 1;
            int currentCap = maxCap;
            int length = stack.Count;
            while(stack.Count!=0)
            {
                if (stack.Peek() < currentCap)
                {
                    currentCap -= stack.Pop();
                }

                else if (stack.Peek() == currentCap)
                {
                    currentCap -= stack.Pop();
                    if (stack.Count > 0)
                    {
                        racks++;
                        currentCap = maxCap;
                    }
                }
                else if (stack.Peek() > currentCap)
                {
                    racks++;
                    currentCap = maxCap;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
