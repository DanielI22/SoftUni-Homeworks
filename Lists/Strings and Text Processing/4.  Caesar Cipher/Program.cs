using System;
using System.Text;

namespace _4.__Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            foreach (char c in input)
            {
                output.Append((char)(c + 3));
            }
            Console.WriteLine(output);
        }
    }
}
