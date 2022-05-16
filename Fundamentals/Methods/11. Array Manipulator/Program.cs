using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end") break;

                string[] commandArray = command.Split();
                string com1 = commandArray[0];
                string com2 = commandArray[1];
                string com3 = commandArray[2];

                if(com1 == "exchange")
                {
                    int index = int.Parse(com2);
                    if(index < 0 || index >= myArr.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                }

            }
        }
    }
}
