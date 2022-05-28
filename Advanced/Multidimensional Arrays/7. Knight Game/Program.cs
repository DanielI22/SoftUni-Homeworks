using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] a = new char[n,n];

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = row[j];
                }
            }


            int br = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if(a[i,j] == 'K')
                    {
                        
                    }
                }
            }
        }
    }
}
