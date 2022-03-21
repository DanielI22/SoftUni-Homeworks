using System;

namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void matrix(int n)
        {
            for(int i = 1; i <=n; i++)
            {
                for(int j = 1; j <=n; j++)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            matrix(int.Parse(Console.ReadLine()));
        }
    }
}
