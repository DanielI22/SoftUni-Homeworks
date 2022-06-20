using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int beaverRow = 0;
            int beaverCol = 0;
            int branchesCount = 0;
            List<char> branches = new List<char>();

            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                     .Replace(" ", "")
                     .ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    pond[i, j] = input[j];
                    if (input[j] == 'B')
                    {
                        beaverRow = i;
                        beaverCol = j;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                if(command == "up")
                {
                    pond[beaverRow, beaverCol] = '-';
                    beaverRow--;

                    if (beaverRow < 0)
                    {
                        if (branches.Count > 0)
                        {
                            branches.Remove(branches.Last());
                        }
                        beaverRow++;
                    }

                    if (char.IsLower(pond[beaverRow,beaverCol]))
                    {
                        branches.Add(pond[beaverRow,beaverCol]);
                    }

                    

                    if(pond[beaverRow,beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverRow != 0)
                        {
                            beaverRow = 0;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                        else if(beaverRow == 0)
                        {
                            beaverRow = n - 1;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                    }

                    pond[beaverRow, beaverCol] = 'B';
                }

                else if (command == "down")
                {
                    pond[beaverRow, beaverCol] = '-';
                    beaverRow++;

                    if (beaverRow == n)
                    {
                        if (branches.Count > 0)
                        {
                            branches.Remove(branches.Last());
                        }
                        beaverRow--;
                    }

                    if (char.IsLower(pond[beaverRow, beaverCol]))
                    {
                        branches.Add(pond[beaverRow, beaverCol]);
                    }

                    

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverRow != n - 1)
                        {
                            beaverRow = n - 1;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                        else if (beaverRow == n - 1)
                        {
                            beaverRow = 0;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                    }

                    pond[beaverRow, beaverCol] = 'B';
                }

                else if (command == "left")
                {
                    pond[beaverRow, beaverCol] = '-';
                    beaverCol--;

                    if (beaverCol < 0)
                    {
                        if (branches.Count > 0)
                        {
                            branches.Remove(branches.Last());
                        }
                        beaverCol++;
                    }

                    if (char.IsLower(pond[beaverRow, beaverCol]))
                    {
                        branches.Add(pond[beaverRow, beaverCol]);
                    }

                    

                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverCol != 0)
                        {
                            beaverCol = 0;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                        else if (beaverCol == 0)
                        {
                            beaverCol = n - 1;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                    }

                    pond[beaverRow, beaverCol] = 'B';
                }
                else if (command == "right")
                {
                    pond[beaverRow, beaverCol] = '-';
                    beaverCol++;


                    if (beaverCol == n)
                    {
                        if(branches.Count > 0)
                        {
                            branches.Remove(branches.Last());
                        }
                        beaverCol--;
                    }

                    if (char.IsLower(pond[beaverRow, beaverCol]))
                    {
                        branches.Add(pond[beaverRow, beaverCol]);
                    }


                    if (pond[beaverRow, beaverCol] == 'F')
                    {
                        pond[beaverRow, beaverCol] = '-';
                        if (beaverCol != n - 1)
                        {
                            beaverCol = n - 1;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                        else if (beaverCol == n - 1)
                        {
                            beaverCol = 0;
                            if (char.IsLower(pond[beaverRow, beaverCol]))
                            {
                                branches.Add(pond[beaverRow, beaverCol]);
                            }
                        }
                    }

                    pond[beaverRow, beaverCol] = 'B';
                }

                bool isFinished = true;
                for(int i = 0; i < pond.GetLength(0); i++)
                {
                    for(int j = 0; j < pond.GetLength(1); j++)
                    {
                        if(char.IsLower(pond[i, j]))
                        {
                            isFinished = false;
                        }
                    }
                }

                if(isFinished)
                {
                    Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
                    for (int i = 0; i < pond.GetLength(0); i++)
                    {
                        for (int j = 0; j < pond.GetLength(1); j++)
                        {
                            Console.Write(pond[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                    return;
                }

                command = Console.ReadLine();
            }


            for (int i = 0; i < pond.GetLength(0); i++)
            {
                for (int j = 0; j < pond.GetLength(1); j++)
                {
                    if(char.IsLower(pond[i,j]))
                    {
                        branchesCount++;
                    } 
                }
            }

            Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            for(int i = 0; i < pond.GetLength(0); i++)
            {
                for(int j = 0; j < pond.GetLength(1); j++)
                {
                    Console.Write(pond[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
