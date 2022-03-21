using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static int sum(int a, int b)
        {
            return a + b;
        }

        static int sub(int a, int b)
        {
            return a - b;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int res = sub(sum(a,b),c);
            Console.WriteLine(res);
        }
    }
}
