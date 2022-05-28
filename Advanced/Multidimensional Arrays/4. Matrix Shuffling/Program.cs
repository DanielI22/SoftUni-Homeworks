using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(' ');

                if(tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;
                }

                string mainCommand = tokens[0];
                int r1 = int.Parse(tokens[1]);
                int c1 = int.Parse(tokens[2]);
                int r2 = int.Parse(tokens[3]);
                int c2 = int.Parse(tokens[4]);

                if (mainCommand != "swap"
                    || r1 < 0 || r1 >= a.GetLength(0)
                    || c1 < 0 || c1 >= a.GetLength(1)
                    || r2 < 0 || r2 >= a.GetLength(0)
                    || c2 < 0 || c2 >= a.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    command = Console.ReadLine();
                    continue;

                }

                string temp = a[r1, c1];
                a[r1, c1] = a[r2, c2];
                a[r2, c2] = temp;

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        Console.Write(a[i,j] + " ");
                    }
                    Console.WriteLine();
                }


                command = Console.ReadLine();
            }
        }
    }
}
