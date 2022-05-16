using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\|([A-Z]{4,})\|:\#([a-zA-Z]+\s[a-zA-Z]+)\#";
            for(int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string bossName = match.Groups[1].Value;
                    string title = match.Groups[2].Value;
                    Console.WriteLine($"{bossName}, The {title}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armor: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
