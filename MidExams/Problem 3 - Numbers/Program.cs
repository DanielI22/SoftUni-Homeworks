using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> intList = Console.ReadLine().Split().Select(int.Parse).ToList();

            intList.Sort();
            intList.Reverse();
            List<int> finalList = new List<int>();
            for (int i = 0; i < intList.Count; i++)
            {
                if (intList[i] > intList.Average())
                {
                    finalList.Add(intList[i]);
                }
                if (i == 4)
                {
                    break;
                }
            }
            if (finalList.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(String.Join(" ", finalList));
            }

        }
    }
}
