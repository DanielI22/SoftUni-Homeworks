using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>([A-Za-z]+)<<(\d+\.?\d+)!(\d+)";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            double sum = 0;
            List<string> items = new List<string>();

            while(input != "Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {
                    items.Add(match.Groups[1].ToString());
                    double curSum = double.Parse(match.Groups[2].Value);
                    int quantity = int.Parse(match.Groups[3].Value);
                    sum += curSum * quantity;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}
