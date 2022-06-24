using System;

namespace _2._Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];
            int myTokensCount = 0;
            int oppTokensCount = 0;

            for (int i = 0; i < n; i++)
            {
                char[] row = Console.ReadLine().Replace(" ","").ToCharArray();

                beach[i] = row;
            }

            string command = Console.ReadLine();

            while(command != "Gong")
            {
                string[] tokens = command.Split(' ');
                string mainCommand = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);


                if(mainCommand == "Find")
                {
                    if(isValid(row, col))
                    {
                        if(beach[row][col] == 'T')
                        {
                            myTokensCount++;
                            beach[row][col] = '-';
                        }
                    }
                }
                else if(mainCommand == "Opponent")
                {
                    string direction = tokens[3];
                    if(isValid(row, col))
                    {
                        if(beach[row][col] == 'T')
                        {
                            oppTokensCount++;
                            beach[row][col] = '-';
                        }


                        if (direction == "up")
                        {
                            for (int j = 1; j <= 3; j++)
                            {
                                if (isValid(row - j, col))
                                {
                                    if (beach[row - j][col] == 'T')
                                    {
                                        oppTokensCount++;
                                        beach[row - j][col] = '-';
                                    }
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int j = 1; j <= 3; j++)
                            {
                                if (isValid(row + j, col))
                                {
                                    if (beach[row + j][col] == 'T')
                                    {
                                        oppTokensCount++;
                                        beach[row + j][col] = '-';

                                    }
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int j = 1; j <= 3; j++)
                            {
                                if (isValid(row, col - j))
                                {
                                    if (beach[row][col - j] == 'T')
                                    {
                                        oppTokensCount++;
                                        beach[row][col - j] = '-';

                                    }
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int j = 1; j <= 3; j++)
                            {
                                if (isValid(row, col + j))
                                {
                                    if (beach[row][col + j] == 'T')
                                    {
                                        oppTokensCount++;
                                        beach[row][col + j] = '-';

                                    }
                                }
                            }
                        }
                    }
                  
                }
                command = Console.ReadLine();
            }


            foreach (var item in beach)
            {
                Console.WriteLine(String.Join(' ', item));
            }
            Console.WriteLine($"Collected tokens: {myTokensCount}");
            Console.WriteLine($"Opponent's tokens: {oppTokensCount}");


            bool isValid(int row, int col)
            {
                if (row >= 0 && row < n && col >=0 && col < beach[row].Length)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
