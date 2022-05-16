using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bomb = tokens[0];
            int power = tokens[1];
            int index = 0;
            while(numbers.Contains(bomb))
            {
                index = numbers.IndexOf(bomb);
                int startindex = index - power;
                int endindex = index + power;
                int leftrange = power;
                int rightrange = power;
                if(startindex < 0)
                {
                    leftrange = index;
                }
                if (endindex >= numbers.Count)
                {
                    rightrange = numbers.Count - 1 - index;
                }
                numbers.RemoveRange(index - leftrange, leftrange + 1 + rightrange);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
