using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static bool isTop(int n)
        {
            int n1 = n;
            int sum = 0;
            while(n1 > 0)
            {
                sum += n1 % 10;
                n1 /= 10;
            }


            int n2 = n;
            bool flag = false;
            while(n2 > 0)
            {
                int tmp = n2 % 10;
                if (tmp % 2 !=0)
                {
                    flag = true;
                }
                n2 /= 10;
            }


            if(sum % 8 != 0)
            {
                return false;
            }
            if (!flag)
            {
                return false;
            }

            return true;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                if(isTop(i))
                    Console.WriteLine(i);
            }
        }
    }
}
