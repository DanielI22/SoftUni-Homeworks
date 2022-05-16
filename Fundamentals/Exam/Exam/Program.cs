using System;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double energy = double.Parse(Console.ReadLine());
            double water = double.Parse(Console.ReadLine());
            double food = double.Parse(Console.ReadLine());

            double sumwater = water * players*n;
            double sumfood = food * players*n;
            for(int i = 1; i<= n; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if(energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {sumfood:f2} food and {sumwater:f2} water.");
                    return;
                }
                if(i %2 == 0)
                {
                    energy = energy * 1.05;
                    sumwater = sumwater * 0.7;
                }
                if(i%3 == 0)
                {
                    sumfood -= sumfood / players;
                    energy = energy * 1.10;
                }



            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
        }
    }
}
