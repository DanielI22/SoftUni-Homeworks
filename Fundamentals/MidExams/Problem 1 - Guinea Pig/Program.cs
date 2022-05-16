using System;

namespace Problem_1___Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodQuant = double.Parse(Console.ReadLine());
            double hayQuant = double.Parse(Console.ReadLine());
            double coverQuant = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());

            double foodGr = foodQuant * 1000;
            double hayGr = hayQuant * 1000;
            double coverGr = coverQuant * 1000;
            double weightGr = weight * 1000;

            for(int i = 1; i<=30; i++)
            {
                foodGr -= 300;

                if(i%2 == 0)
                {
                    hayGr -= foodGr * 0.05;
                }

                if(i%3 == 0)
                {
                    coverGr -= weightGr / 3;
                }

                if(foodGr < 0 || hayGr <0 || coverGr < 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }
            }

            Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodGr/1000:f2}, Hay: {hayGr / 1000:f2}, Cover: {coverGr / 1000:f2}.");
        }
    }
}
