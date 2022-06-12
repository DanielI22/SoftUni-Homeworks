using System;
using System.Collections.Generic;

namespace Swap
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            int n = int.Parse(Console.ReadLine());
            
            for(int i = 0; i < n; i++)
            {
                myList.Add(int.Parse(Console.ReadLine()));
            }

            string[] swapCommand = Console.ReadLine().Split(" ");
            int index1 = int.Parse(swapCommand[0]);
            int index2 = int.Parse(swapCommand[1]);

            Swap(myList, index1, index2);

            foreach (var item in myList)
            {
                Console.WriteLine(item.GetType().ToString() + ": " + item);
            }
        }


        static void Swap<T>(List<T> list, int index1, int index2)  
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}
