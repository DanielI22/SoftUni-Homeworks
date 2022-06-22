using System;

namespace _2._Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] chessBoard = new char[8,8];


            int whitePawnRow = 0;
            int blackPawnRow = 0;
            int whitePawnCol = 0;
            int blackPawnCol = 0;

            for(int i = 7; i >= 0; i--)
            {
                char[] row = Console.ReadLine().ToCharArray();
                for(int j = 7; j >= 0; j--)
                {
                    chessBoard[i,j] = row[j];

                    if(chessBoard[i,j] == 'w')
                    {
                        whitePawnRow = i;
                        whitePawnCol = j;
                    }

                    if(chessBoard[i,j] == 'b')
                    {
                        blackPawnRow = i;
                        blackPawnCol = j;
                    }
                }
            }

            while (true)
            {
                if (whitePawnRow == blackPawnRow - 1 && (whitePawnCol == blackPawnCol + 1 || whitePawnCol == blackPawnCol - 1))
                {
                    Console.WriteLine($"Game over! White capture on {(char)(blackPawnCol + 97)}{blackPawnRow + 1}.");
                    break;
                }
                whitePawnRow++;
                if (whitePawnRow == 7)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whitePawnCol + 97)}{whitePawnRow + 1}.");
                    break;

                }
                if (blackPawnRow == whitePawnRow + 1 && (blackPawnCol == whitePawnCol + 1 || blackPawnCol == whitePawnCol - 1))
                {
                    Console.WriteLine($"Game over! Black capture on {(char)(whitePawnCol + 97)}{whitePawnRow + 1}.");
                    break;
                }
                blackPawnRow--;
                if(blackPawnRow == 0)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackPawnCol + 97)}{blackPawnRow + 1}.");
                    break;
                }
            }
        }
    }
}
