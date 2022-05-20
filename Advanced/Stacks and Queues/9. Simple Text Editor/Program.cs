using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            stack.Push("");
            StringBuilder currentText = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                string main = command[0];
                if (main == "1")
                {
                    string text = command[1];
                    currentText.Append(text);
                    stack.Push(currentText.ToString());
                }
                else if (main == "2")
                {
                    int count = int.Parse(command[1]);
                    for(int j = 0; j < count; j++)
                    {
                        currentText.Length--;
                    }
                    stack.Push(currentText.ToString());
                }
                else if(main == "3")
                {
                    int index = int.Parse(command[1]);    
                    Console.WriteLine(currentText[index-1]);
                }
                else if(main == "4")
                {
                    if(stack.Count > 1)
                    {
                        stack.Pop();
                        currentText = new StringBuilder(stack.Peek());
                    } 
                }
            }
        }
    }
}
