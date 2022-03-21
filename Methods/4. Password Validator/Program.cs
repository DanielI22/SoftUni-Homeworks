using System;

namespace _4._Password_Validator
{
    internal class Program
    {
        static bool validLen(string pass)
        {
            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }
            else return false;
        }

        static bool validType(string pass)
        {
            bool flag = true;
            for (int i = 0; i < pass.Length; i++)
            {
                if (!Char.IsLetterOrDigit(pass[i]))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        static bool validDig(string pass)
        {
            int digFlag = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= 48 && pass[i] <= 57)
                {
                    digFlag++;
                }
            }
            if (digFlag >= 2)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            if(!validLen(pass))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!validType(pass))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!validDig(pass))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if(validLen(pass) && validType(pass) && validDig(pass))
            {
                Console.WriteLine("Password is valid");
            }

        }
    }
}
