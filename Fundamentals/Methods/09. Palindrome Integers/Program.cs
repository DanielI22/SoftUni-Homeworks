using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static bool isPali(int n)
        {
            string s = n.ToString();
            int len = s.Length;
            for(int i = 0; i < len/2; i++)
            {
                if (s[i] != s[len - i - 1])
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            while(true)
            {
                string command = Console.ReadLine();
                if (command == "END") break;
                int num = int.Parse(command);

                if (isPali(num)) Console.WriteLine("true");
                else Console.WriteLine("false");
                
            }
        }
    }
}
