using System;

namespace Rage_expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            for (int i=1; i<=n; i++)
            {
                double ppc = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int cc = int.Parse(Console.ReadLine());

                double price = ppc * days * cc;
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
