using System;
using System.Collections.Generic;

namespace _6._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(inputArr);

            while(queue.Count != 0)
            {
                string[] command = Console.ReadLine().Split(new[] {' '}, 2);
                string Mcommand = command[0];
                
                
                if(Mcommand == "Play")
                {
                    queue.Dequeue();
                }
                else if (Mcommand == "Add")
                {
                    string song = command[1];
                    if (!queue.Contains(song))
                    {
                        queue.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (Mcommand == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue.ToArray()));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
