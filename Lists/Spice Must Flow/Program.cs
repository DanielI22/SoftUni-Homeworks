using System;
namespace Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long maxValue = 0;
            int maxSnow = 0;
            int maxTime = 0;
            int maxQua = 0;
            for (int i =0; i< n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                long snowballValue = (long)Math.Pow((double)(snowballSnow / snowballTime), snowballQuality);
                if (snowballValue >= maxValue) 
                { 
                    maxValue = snowballValue;
                    maxSnow = snowballSnow;
                    maxTime = snowballTime;
                    maxQua = snowballQuality;
                }
            }
            Console.WriteLine($"{maxSnow} : {maxTime} = {maxValue} ({maxQua})");
        }
    }
}
