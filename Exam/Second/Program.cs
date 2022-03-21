using System;

namespace Second
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(">>", StringSplitOptions.RemoveEmptyEntries);

            double tax = 0;
            double totaltax = 0;
            for(int i=0; i<input.Length; i++)
            {
                string[] tokens = input[i].Split();
                string car = tokens[0];
                int years = int.Parse(tokens[1]);
                int kilometres = int.Parse(tokens[2]);

                if (car == "family")
                {
                    tax = 50;
                    tax -= years * 5;
                    tax += (kilometres / 3000) * 12;
                }
                else if(car == "heavyDuty")
                {
                    tax = 80;
                    tax -= years * 8;
                    tax += (kilometres / 9000) * 14;
                }
                else if(car == "sports")
                {
                    tax = 100;
                    tax -= years * 9;
                    tax += (kilometres / 2000) * 18;
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }
                Console.WriteLine($"A {car} car will pay {tax:f2} euros in taxes.");
                totaltax += tax;
            }
            Console.WriteLine($"The National Revenue Agency will collect {totaltax:f2} euros in taxes.");
        }
    }
}
