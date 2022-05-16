using System;

namespace _8.__Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char leftChar = input[i][0];
                char rightChar = input[i][input[i].Length - 1];
                double num = double.Parse(input[i].Substring(1, input[i].Length - 2));
                if(Char.IsUpper(leftChar))
                {
                    num /= (leftChar - 64);
                }
                else
                {
                    num *= (char.ToUpper(leftChar) - 64);
                }
                if(Char.IsUpper(rightChar))
                {
                    num -= (rightChar - 64);
                }
                else
                {
                    num += (char.ToUpper(rightChar) - 64);
                }
                sum += num;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
