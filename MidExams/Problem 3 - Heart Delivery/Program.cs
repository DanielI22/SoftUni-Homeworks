using System;
using System.Linq;

namespace Problem_3___Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            int currentPos = 0;
            while(command != "Love!")
            {
                int jumpLength = int.Parse(command.Split()[1]);
                currentPos += jumpLength;

                if(currentPos >= input.Length)
                {
                    currentPos = 0;
                }

                if(input[currentPos] <= 0)
                {
                    Console.WriteLine($"Place {currentPos} already had Valentine's day.");
                }

                input[currentPos] -= 2;

                if(input[currentPos] == 0)
                {
                    Console.WriteLine($"Place {currentPos} has Valentine's day.");
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {currentPos}.");
            int br = 0;
            for(int i=0; i<input.Length; i++)
            {
              if(input[i] <= 0)
                {
                    br++;
                }
            }

            if(br == input.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {input.Length - br} places.");
            }
        }
    }
}
