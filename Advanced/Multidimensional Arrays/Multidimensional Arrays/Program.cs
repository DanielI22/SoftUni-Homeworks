using System;
using System.Linq;

namespace Multidimensional_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] a = new int[n,n];
            for(int i = 0; i < n; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for(int j = 0; j < n; j++)
                {
                    a[i,j] = row[j];
                }
            }

            int sum1 = 0, sum2 = 0, sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                  if(i == j)
                    {
                        sum1 += a[i, j];
                    }

                  if(i + j == n - 1)
                    {
                        sum2 += a[i, j];
                    }
                }
            }


            sum = Math.Abs(sum1 - sum2);
            Console.WriteLine(sum);
        }
    }
}
