using System;
using System.Collections.Generic;

namespace _1._Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i< names.Length; i++)
            {
                if(names[i].Length >=3 && names[i].Length <= 16)
                {
                    bool inval = false;
                    foreach (char c in names[i])
                    {
                        if(!(char.IsLetterOrDigit(c) || c == '-' || c == '_'))
                        {
                            inval = true;
                            break;
                        }
                    }
                    if (inval)
                    {
                        continue;
                    }
                    Console.WriteLine(names[i]);
                }
            }
        }
    }
}
