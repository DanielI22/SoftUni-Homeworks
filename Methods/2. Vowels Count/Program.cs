using System;

namespace _2._Vowels_Count
{
    internal class Program
    {
        static int myMethod()
        {
            string s = Console.ReadLine();
            int vowels = 0;
            for (int i=0; i<s.Length; i++)
            {
                if("aeiuoAEIUO".Contains(s[i]))
                {
                    vowels++;
                }
            }
            return vowels;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(myMethod());
        }
    }
}
