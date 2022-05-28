using System;
using System.Collections.Generic;

namespace Problem_4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var myDic = new Dictionary<int,int>();
            for(int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (!myDic.ContainsKey(currentNum)) 
                {
                    myDic[currentNum] = 1;
                }
                else 
                myDic[currentNum]++;
            }

            foreach (var item in myDic)
            {
                if(item.Value%2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
