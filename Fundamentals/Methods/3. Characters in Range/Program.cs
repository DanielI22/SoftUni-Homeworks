using System;

namespace _3._Characters_in_Range
{
    internal class Program
    {
        static void myMethod()
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());

            if (a <= b)
            {
                for (int i = a + 1; i < b; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
            else
            {
                for (int i = b + 1; i < a; i++)
                {
                    Console.Write((char)i + " ");
                }
            }
        }

        static void Main(string[] args)
        {
            myMethod();
        }
    }
}
