using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void printMid()
        {
            string s = Console.ReadLine();

            if(s.Length % 2 == 0)
            {
                Console.Write(s[s.Length/2 - 1] + "" + s[s.Length/2]);
            }
            else
            {
                Console.Write(s[s.Length/2]);
            }
        }
        static void Main(string[] args)
        {
            printMid();
        }
    }
}
