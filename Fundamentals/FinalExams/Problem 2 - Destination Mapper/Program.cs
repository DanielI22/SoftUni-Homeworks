using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=/])([A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);
            int travelPoints = 0;
            List<string> destinations = new List<string>();
            foreach (Match match in matches)
            {
                destinations.Add(match.Groups[2].Value);
                travelPoints+=match.Groups[2].Value.Length;
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
