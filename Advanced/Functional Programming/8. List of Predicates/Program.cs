using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> list = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                list.Add(i);
            }

            foreach (var item in dividers)
            {
                list = list.Where(x => x % item == 0).ToList();
            }

            Console.WriteLine(String.Join(' ', list));
        }
    }
}
