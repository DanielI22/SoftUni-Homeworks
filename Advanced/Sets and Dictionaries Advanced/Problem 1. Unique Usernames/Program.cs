using System;
using System.Collections.Generic;

namespace Problem_1._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();
            for(int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join('\n', set));
        }
    }
}
