using System;

namespace _1._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static int myMethod()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            if (a <= b && a <= c)
            {
                return a;
            }
            else if (b <= a && b <= c)
            {
                return b;
            }
            else if (c <= a && c <= b)
            {
                return c;
            }
            return a;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(myMethod());
        }
    }
}
