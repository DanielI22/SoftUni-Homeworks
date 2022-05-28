using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            string snake = Console.ReadLine();

            char[,] a = new char[rows, cols];
            int snakeindex = 0;
            for (int i = 0; i < rows; i++)
            {

                if (i % 2 == 0)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        a[i, j] = snake[snakeindex];

                        snakeindex++;
                        if (snakeindex >= snake.Length)
                        {
                            snakeindex = 0;
                        }
                    }
                }

                else
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        a[i, j] = snake[snakeindex];

                        snakeindex++;
                        if (snakeindex >= snake.Length)
                        {
                            snakeindex = 0;
                        }
                    }
                }
              
            }


            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
