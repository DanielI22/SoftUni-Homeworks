using System;
using System.Collections.Generic;

namespace Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] expression = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();
            bool balanced = true;
            foreach (char item in expression)
            {
                if(item == '(' || item == '[' || item == '{') {
                    stack.Push(item);
                }
                if (item == ')')
                {
                    if(stack.Count == 0) { balanced = false; }
                    else if (stack.Pop() != '(') 
                    {
                        balanced = false;
                        break;
                    }    
                }
                if (item == ']')
                {
                    if (stack.Count == 0) { balanced = false; }
                   else if (stack.Count > 0 && stack.Pop() != '[')
                    {
                        balanced = false;
                        break;
                    }
                }
                if (item == '}')
                {
                    if (stack.Count == 0) { balanced = false; }
                    else if (stack.Count > 0 && stack.Pop() != '{')
                    {
                        balanced = false;
                        break;
                    }
                }
            }
            if (balanced && stack.Count==0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
