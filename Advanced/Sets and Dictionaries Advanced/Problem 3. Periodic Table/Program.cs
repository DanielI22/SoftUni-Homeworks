using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in currentRow)
                {
                    set.Add(item);
                }
            }


            Console.WriteLine(String.Join(" ", set.OrderBy(n => n)));
        }
    }
}
