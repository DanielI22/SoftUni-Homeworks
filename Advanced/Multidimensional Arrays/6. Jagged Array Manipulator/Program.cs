using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] a = new int[rows][];

            for(int i = 0; i < rows; i++)
            {
                int[] inputRow = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                a[i] = inputRow;
            }


            for (int i = 0; i < rows - 1; i++)
            {
                if (a[i].Length == a[i+1].Length)
                {
                    a[i] = a[i].Select(el => el*2).ToArray();
                    a[i + 1] = a[i + 1].Select(el => el*2).ToArray();
                }

                else
                {
                    a[i] = a[i].Select(el => el / 2).ToArray();
                    a[i+ 1] = a[i + 1].Select(el => el / 2).ToArray();
                }
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] tokens = command.Split(' ');

                string mainCom = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if(mainCom == "Add")
                {
                    if(row >= 0 && row < a.Length && col >=0 && col < a[row].Length)
                    {
                        a[row][col] += value;
                    }
                }
                else if(mainCom == "Subtract")
                {
                    if (row >= 0 && row < a.Length && col >= 0 && col < a[row].Length)
                    {
                        a[row][col] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var item in a) 
            {
                Console.WriteLine(String.Join(" ", item));
            }
        }
    }
}
