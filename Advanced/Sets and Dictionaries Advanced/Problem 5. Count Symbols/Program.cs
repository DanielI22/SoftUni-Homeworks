using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var myDic = new Dictionary<char, int>();

            foreach (var item in input)
            {
                if(myDic.ContainsKey(item))
                {
                    myDic[item]++;
                }
                else { myDic[item] = 1; }
            }

            foreach (var item in myDic.OrderBy(n => n.Key))
            {
                Console.WriteLine(item.Key + ": " +item.Value + " time/s");
            }
        }
    }
}
