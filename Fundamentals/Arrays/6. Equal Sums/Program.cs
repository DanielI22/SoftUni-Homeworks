using System;
using System.Linq;

namespace _6._Equal_Sums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool flag = false;
            for (int i = 0; i < arr.Length; i++)
            {
                int leftsum = 0;
                int rightsum = 0;

                for(int j = 0; j < i; j++)
                {
                    leftsum += arr[j];
                }

                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightsum += arr[j];
                }

                if(leftsum == rightsum)
                {
                    Console.WriteLine(i);
                    flag = true;
                }
            }
            if (!flag) Console.WriteLine("no");
        }
    }
}
