using System;

namespace Data_Types_and_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int length = n1.ToString().Length;
            int sum = 0;
            for(int i=0; i < n1.ToString().Length; i++)
            {
                int n2 = n1 % 10;
                n1 = n1 / 10;
                sum += n2;
            }
            Console.WriteLine(sum);
        }
    }
}
