using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr1 = new string[n];
            string[] arr2 = new string[n];

            for (int i = 0; i < n; i++)
            {
                string[] tempArr = Console.ReadLine().Split();
                if (i % 2 != 0)
                {
                    arr1[i] = tempArr[0];
                    arr2[i] = tempArr[1];
                }
                else
                {
                    arr1[i] = tempArr[1];
                    arr2[i] = tempArr[0];
                }
            }
            Console.WriteLine(String.Join(" ", arr2));
            Console.WriteLine(String.Join(" ", arr1));
        }
    }
}
