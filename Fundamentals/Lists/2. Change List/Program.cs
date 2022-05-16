using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listN = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();

            while(command != "end")
            {
                string mainC = command.Split()[0];

                if(mainC == "Delete")
                {
                    int ele = int.Parse(command.Split()[1]);
                    for (int i = 0; i < listN.Count; i++)
                    {
                        if(ele == listN[i])
                        {
                            listN.Remove(ele);
                        }
                    }

                }
                else if(mainC == "Insert")
                {
                    int ele = int.Parse(command.Split()[1]);
                    int pos = int.Parse(command.Split()[2]);
                    listN.Insert(pos, ele);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", listN));
        }
    }
}
