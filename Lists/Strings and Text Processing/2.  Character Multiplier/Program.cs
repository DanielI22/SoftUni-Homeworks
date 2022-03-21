using System;
using System.Numerics;

namespace _2.__Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ' , StringSplitOptions.RemoveEmptyEntries);
            if(input.Length == 2)
            {
                Console.WriteLine(sumString(input[0], input[1]));
            }
        }

        static BigInteger sumString(string s1, string s2)
        {
            BigInteger sum = 0;
            for (int i = 0; i < Math.Min(s1.Length, s2.Length); i++)
            {
                sum += s1[i] * s2[i];
            }
            for(int i = Math.Min(s1.Length, s2.Length); i < Math.Max(s1.Length, s2.Length); i++)
            {
                if(s1.Length == Math.Max(s1.Length, s2.Length))
                {
                    sum += s1[i];
                }
                else
                {
                    sum += s2[i];
                }
            }
            return sum;
        }
    }
}
