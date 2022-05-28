using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int n = input[0];
            int m = input[1];

            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            for(int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                set1.Add(currentNum);
            }

            for(int i = 0; i < m; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                set2.Add(currentNum);
            }

            var finalset = new HashSet<int>();

            foreach (var item in set1)
            {
                if (set2.Contains(item))
                {
                    finalset.Add(item);
                }
            }

            Console.WriteLine(String.Join(" ", finalset));
        }
    }
}
