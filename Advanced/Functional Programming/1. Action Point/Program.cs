using System;
using System.Linq;

namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = x => Console.WriteLine(x);

            string[] input = Console.ReadLine().Split(' ');

            Array.ForEach(input, action);
        }
    }
}
