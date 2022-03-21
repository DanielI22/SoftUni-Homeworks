using System;
using System.Text;

namespace _7._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());
            int power = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '>' && power > 0)
                {
                    input.Remove(i, 1);
                    power--;
                    i--;
                }
                else if(input[i] == '>')
                {
                    power += input[i + 1] - '0';
                }
            }
            Console.WriteLine(input);
        }
    }
}
