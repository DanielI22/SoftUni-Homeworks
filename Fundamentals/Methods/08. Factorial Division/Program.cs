using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static long fact(int n)
        {
            long res = 1;
            for (int i = 2; i <=n; i++)
            {
                res = res * i;
            }
            return res;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double res = (double)fact(a) / fact(b);
            Console.WriteLine($"{res:f2}");
        }
    }
}
