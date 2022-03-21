using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            input.Reverse();
            List<int> output = new List<int>();
            foreach(string word in input)
            {
                List<int> curChar = word.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (int item in curChar)
                {
                    output.Add(item);
                }
            }
            Console.WriteLine(String.Join(" ", output));
        }
    }
}
