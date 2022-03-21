using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = 0;
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                int br = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        num = arr[i];
                        br++;
                    }
                    else break;
                }
                tempArr[i] = br;
            }

            int max = 0;
            int maxindex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (tempArr[i] > max)
                {
                    max = tempArr[i];
                    maxindex = i;
                }
            }
            for (int i = 0; i < max; i++)
            {
                Console.Write(arr[maxindex] + " ");
            }
        }
    }
}
