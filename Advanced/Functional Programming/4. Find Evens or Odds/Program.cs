using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int min = input[0];
            int max = input[1];
            string command = Console.ReadLine();

            List<int> list = new List<int>();

            for(int i = min; i <= max; i++)
            {
                list.Add(i);
            }

            if (command == "odd")
            {
                Console.Write(string.Join(" ", list.Where(x => isOdd(x)).ToList()));
            }


            if (command == "even")
            {
                Console.Write(string.Join(" " ,list.Where(x => isEven(x)).ToList()));
            }
        }
    }
}
