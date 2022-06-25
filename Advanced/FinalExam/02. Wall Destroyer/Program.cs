using System;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int holesCount = 1;
            int rodesHit = 0;

            int currentRow = 0;
            int currentCol = 0;


            for (int i = 0; i < n; i++)
            {
                char[] input = Console.ReadLine()
                     .ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    wall[i, j] = input[j];

                    if (wall[i, j] == 'V')
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow++;
                        continue;
                    }

                    if (wall[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodesHit++;
                        currentRow++;
                        continue;
                    }

                    else if (wall[currentRow, currentCol] == 'C')
                    {
                        wall[currentRow, currentCol] = 'E';
                        wall[currentRow + 1, currentCol] = '*';

                        holesCount++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return;
                    }

                    else if (wall[currentRow, currentCol] == '*')
                    {
                        wall[currentRow + 1, currentCol] = '*';

                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }

                    else if (wall[currentRow, currentCol] == '-')
                    {
                        wall[currentRow + 1, currentCol] = '*';
                        holesCount++;
                    }
                }
                else if (command == "down")
                {
                    currentRow++;
                    if (currentRow == n)
                    {
                        currentRow--;
                        continue;
                    }

                    if (wall[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodesHit++;
                        currentRow--;
                        continue;
                    }

                    else if (wall[currentRow, currentCol] == 'C')
                    {
                        wall[currentRow, currentCol] = 'E';
                        wall[currentRow - 1, currentCol] = '*';

                        holesCount++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return;
                    }

                    else if (wall[currentRow, currentCol] == '*')
                    {
                        wall[currentRow - 1, currentCol] = '*';

                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }

                    else if (wall[currentRow, currentCol] == '-')
                    {
                        wall[currentRow - 1, currentCol] = '*';
                        holesCount++;
                    }
                }
                else if (command == "right")
                {
                    currentCol++;
                    if (currentCol == n)
                    {
                        currentCol--;
                        continue;
                    }

                    if (wall[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodesHit++;
                        currentCol--;
                        continue;
                    }

                    else if (wall[currentRow, currentCol] == 'C')
                    {
                        wall[currentRow, currentCol] = 'E';
                        wall[currentRow, currentCol - 1] = '*';
                        holesCount++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return;
                    }

                    else if (wall[currentRow, currentCol] == '*')
                    {
                        wall[currentRow, currentCol - 1] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }

                    else if (wall[currentRow, currentCol] == '-')
                    {
                        wall[currentRow, currentCol - 1] = '*';
                        holesCount++;
                    }
                }
                else if (command == "left")
                {
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol++;
                        continue;
                    }

                    if (wall[currentRow, currentCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodesHit++;
                        currentCol++;
                        continue;
                    }

                    else if (wall[currentRow, currentCol] == 'C')
                    {
                        wall[currentRow, currentCol] = 'E';
                        wall[currentRow, currentCol + 1] = '*';
                        holesCount++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCount} hole(s).");
                        for (int i = 0; i < wall.GetLength(0); i++)
                        {
                            for (int j = 0; j < wall.GetLength(1); j++)
                            {
                                Console.Write(wall[i, j]);
                            }
                            Console.WriteLine();
                        }
                        return;
                    }

                    else if (wall[currentRow, currentCol] == '*')
                    {
                        wall[currentRow, currentCol + 1] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    }

                    else if(wall[currentRow, currentCol] == '-')
                    {
                        wall[currentRow, currentCol + 1] = '*';
                        holesCount++;
                    }
                }


                if (command == "End")
                {
                    wall[currentRow, currentCol] = 'V';
                    break;
                }
            }

            Console.WriteLine($"Vanko managed to make {holesCount} hole(s) and he hit only {rodesHit} rod(s).");
            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    Console.Write(wall[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}