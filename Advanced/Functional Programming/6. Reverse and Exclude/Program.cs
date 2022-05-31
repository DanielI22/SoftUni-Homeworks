using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int n = int.Parse(Console.ReadLine());

            Predicate<int> predicate = x => x % n == 0;


            list.RemoveAll(predicate);
            list.Reverse();

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
