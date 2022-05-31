using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Func<int, int> add = a => a + 1;
            Func<int, int> subtract = a => a - 1;
            Func<int, int> multiply = a => a * 2;
            Action<string> print = a => Console.WriteLine(a);

            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while(command != "end")
            {
                if(command == "add")
                {
                    list = list.Select(add).ToList();
                }
                else if (command == "subtract")
                {
                    list = list.Select(subtract).ToList();
                }
                else if (command == "multiply")
                {
                    list = list.Select(multiply).ToList();
                }
                else if (command == "print")
                {
                    print(string.Join(" ", list));
                }

                command = Console.ReadLine();
            }
        }      
    }
}
