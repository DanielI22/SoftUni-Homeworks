using System;
using System.Text.RegularExpressions;

namespace _3._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalIncome = 0;

            string pattern = @"%([A-z][a-z]+)%[^\|$%\.\d]*<(\w+)>[^\|$%\.\d]*\|(\d+)\|[^\|$%\.\d]*(\d+\.?\d+)\$";

            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if(match.Success)
                {
                    string name = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double totalPrice = quantity * price;
                    totalIncome += totalPrice;

                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
                
                input  = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
