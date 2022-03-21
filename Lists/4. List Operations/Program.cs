using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listC = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while(command!= "End")
            {
                string[] tokens = command.Split();
                string mainComm = tokens[0];

                if(mainComm == "Add")
                {
                    int num = int.Parse(tokens[1]);
                    listC.Add(num);
                }
                else if (mainComm == "Insert")
                {
                    int num = int.Parse(tokens[1]);
                    int index = int.Parse(tokens[2]);
                    if(index < 0 || index >= listC.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                    else listC.Insert(index, num);
                }
                else if (mainComm == "Remove")
                {
                    int index = int.Parse(tokens[1]);
                    if (index < 0 || index >= listC.Count)
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                    else listC.RemoveAt(index);
                }
                else if (mainComm == "Shift")
                {
                    string subCom = tokens[1];
                    if(subCom == "left")
                    {
                        int count = int.Parse(tokens[2]);
                        for(int i=0; i<count; i++)
                        {
                            listC.Add(listC[0]);
                            listC.RemoveAt(0);
                        }
                    }
                    else if(subCom == "right")
                    {
                        int count = int.Parse(tokens[2]);
                        for (int i = 0; i < count; i++)
                        {
                            listC.Insert(0, listC[listC.Count-1]);
                            listC.RemoveAt(listC.Count - 1);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", listC));
        }
    }
}
