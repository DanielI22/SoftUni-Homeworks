using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] orderArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> myQueue = new Queue<int>(orderArray);

            int maxOrder = myQueue.Peek();
            foreach (int item in myQueue)
            {
                if(item > maxOrder) maxOrder = item;
            }

            Console.WriteLine(maxOrder);
            int length = myQueue.Count;
            for (int i = 0; i < length; i++)
            {
                int currentOrder = myQueue.Peek();
                if(n >= currentOrder)
                {
                    n = n - myQueue.Dequeue();
                }
            }

            if(myQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            
            else
            {
                Console.WriteLine("Orders left: " + String.Join(" ", myQueue.ToArray()));
            }
        }
    }
}
