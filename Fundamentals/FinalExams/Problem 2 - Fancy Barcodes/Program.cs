using System;
using System.Text.RegularExpressions;

namespace Problem_2___Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"@#+[A-Z][A-Za-z\d]{4,}[A-Z]@#+";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string productGroup = "";
                    foreach(char c in match.ToString())
                    {
                        if (char.IsDigit(c))
                        {
                            productGroup += c;
                        }
                    }
                    if(productGroup.Length == 0)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
