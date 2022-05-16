using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        double money = 0;
        double nuts = 2;
        double water = 0.7;
        double crisps = 1.5;
        double soda = 0.8;
        double coke = 1;
        while(true)
        {
            string command = Console.ReadLine();
            if (command == "Start") break;
            double coin = double.Parse(command);
            if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
            {
                Console.WriteLine($"Cannot accept {coin}");
            }
            else money += coin;
        }

        while(true)
        {
            string product = Console.ReadLine();
            if (product == "End") break;
            double currentPrice = 0;
            switch (product)
            {
                case "Nuts":
                    currentPrice = nuts;
                    break;
                case "Water":
                    currentPrice = water;
                    break;
                case "Crisps":
                    currentPrice = crisps;
                    break;
                case "Soda":
                    currentPrice = soda;
                    break;
                case "Coke":
                    currentPrice = coke;
                    break;
                default:
                    Console.WriteLine("Invalid product");
                    break;
            }
            if(money >= currentPrice && currentPrice!=0)
            {
                Console.WriteLine($"Purchased {product.ToLower()}");
                money = money - currentPrice;
            }
            else if (money < currentPrice) Console.WriteLine("Sorry, not enough money");
        }
        Console.WriteLine($"Change: {money:f2}");

    }
}
