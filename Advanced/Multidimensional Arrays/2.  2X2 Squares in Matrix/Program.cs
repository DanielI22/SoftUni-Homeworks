using System;
using System.Linq;

namespace _2.__2X2_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] a = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
               string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    a[i, j] = row[j];
                }
            }

            int sum = 0;

            for (int i = 0; i < a.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < a.GetLength(1) - 1; j++)
                {
                    if (a[i, j] == a[i + 1, j] && a[i, j] == a[i, j + 1] && a[i, j] == a[i + 1, j + 1])
                    {
                        sum++;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
