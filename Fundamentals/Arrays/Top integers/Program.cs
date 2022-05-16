using System;
using System.Linq;

namespace Top_integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                bool topIn = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        topIn = false;
                        break;
                    }
                }
                if (topIn)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
