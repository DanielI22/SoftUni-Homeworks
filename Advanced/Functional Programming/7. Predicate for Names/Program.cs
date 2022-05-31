using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(' ').ToList();

            names=names.Where(x => x.Length <= n).ToList();

            Console.WriteLine(String.Join("\n", names));
        }
    }
}
