using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<HashSet<int>, int> func = x => x.Min();

            HashSet<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToHashSet();

            Console.WriteLine(func(list));
        }
    }
}
