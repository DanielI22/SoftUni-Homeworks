using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] a = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] row = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    a[i, j] = row[j];
                }
            }


            int sum = 0;
            int[,] maxArr = new int[3,3];
            for (int i = 0; i < a.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < a.GetLength(1) - 2; j++)
                {
                    int currentSum = a[i, j] + a[i + 1, j] + a[i, j+1] + a[i+2, j] + a[i,j+2] + a[i+1, j + 1] + a[i+1,j + 2] + a[i +2, j+1] + a[i+2, j+2];
                    if(currentSum > sum)
                    {
                        sum = currentSum;
                        maxArr[0,0] = a[i,j];
                        maxArr[1,0] = a[i+1,j];
                        maxArr[2,0] = a[i+2,j];
                        maxArr[0, 1] = a[i, j + 1];
                        maxArr[0, 2] = a[i, j + 2];
                        maxArr[1, 1] = a[i + 1, j + 1];
                        maxArr[1, 2] = a[i + 1,j + 2];
                        maxArr[2, 1] = a[i + 2, j + 1];
                        maxArr[2, 2] = a[i + 2, j + 2];
                    }
                }
            }

            Console.WriteLine("Sum = " + sum);

            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Console.Write(maxArr[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
