using System;
using System.Linq;

namespace _1._Encrypt__Sort__and_Print_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sumarray = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                string name = Console.ReadLine();
                for(int j = 0; j < name.Length; j++)
                {
                    if("AEIOUaeiou".Contains(name[j]))
                    {
                        sum += (int)name[j] * name.Length;
                    }
                    else
                    {
                        sum += (int)name[j] / name.Length;
                    }
                }
                sumarray[i] = sum;
            }
            Array.Sort(sumarray);
            Console.WriteLine(String.Join("\n", sumarray));
        }
    }
}
