using System;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyJohn = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double priceLight = double.Parse(Console.ReadLine());
            double priceRobe = double.Parse(Console.ReadLine());
            double priceBelt = double.Parse(Console.ReadLine());

            double finalPrice = 0;

            int lightCount = (int)Math.Ceiling(countStudents * 1.1);
            double priceL = priceLight * lightCount;
            double priceR = priceRobe * countStudents;
            
            int br = 0;
            for(int i=0; i<countStudents; i++)
            {
                if (i > 5 && i % 6 == 0)
                {
                    br++;
                }
            }
            double priceB = priceBelt * (countStudents - br);

            finalPrice = priceB + priceL + priceR;
            if (finalPrice <= moneyJohn)
            {
                Console.WriteLine($"The money is enough - it would cost {finalPrice:f2}lv.");
            }
            else Console.WriteLine($"John will need {(finalPrice - moneyJohn):f2}lv more.");
        }
    }
}
