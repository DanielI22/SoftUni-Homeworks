using System;
using System.Text;

namespace _6.__Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);
            for(int i = 1; i < input.Length; i++)
            {
                if(input[i] == input[i-1])
                {
                    continue;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }
            Console.WriteLine(sb);
        }
    }
}
