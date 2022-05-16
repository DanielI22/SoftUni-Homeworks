using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Problem_2___Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(::|\*\*)([A-Z][a-z]{2,})\1";
            MatchCollection matches = Regex.Matches(input, pattern);
            BigInteger threshold = 1;
            foreach(char c in input)
            {
                if (char.IsDigit(c))
                {
                    threshold*=(int)c - '0';
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
            foreach (Match match in matches)
            {
                int coolness = 0;
                string letters = match.Groups[2].ToString();
                for(int i = 0; i < letters.Length; i++)
                {
                    coolness += (int)letters[i];
                }
                if(coolness >= threshold)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
