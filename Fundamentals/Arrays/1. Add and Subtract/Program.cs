using System;

namespace _1._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrLen = int.Parse(Console.ReadLine());

            int[] array = new int[arrLen];
            int sum = 0;
            for (int i = 0; i < arrLen; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                sum += array[i];
            }
            for (int i = 0; i < arrLen; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\n" + sum);
        }
    }
}
