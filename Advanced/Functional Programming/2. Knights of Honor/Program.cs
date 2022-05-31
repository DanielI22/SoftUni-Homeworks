using System;

namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine("Sir " + x);

            string[] input = Console.ReadLine().Split(' ');

            Array.ForEach(input, action);
        }
    }
}
