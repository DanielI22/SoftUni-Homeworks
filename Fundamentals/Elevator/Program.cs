using System;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double maxVol = 0;
            string maxKeg = "";
            for (int i = 0; i < n; i++)
            {
                string mod = Console.ReadLine();
                double rad = double.Parse(Console.ReadLine());
                int he = int.Parse(Console.ReadLine());
                double vol = Math.PI * Math.Pow(rad, 2) * he;
                if (vol >= maxVol)
                {
                    maxVol = vol;
                    maxKeg = mod;

                }
            }
            Console.WriteLine(maxKeg);

        }
    }
}
