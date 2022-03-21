using System;
using System.Linq;

namespace Problem_2___Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();

            while(command != "end")
            {
                string[] tokens = command.Split();
                string main = tokens[0];

                if(main == "swap")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);

                    int temp = inputArray[index1];
                    inputArray[index1] = inputArray[index2];
                    inputArray[index2] = temp;
                }
                else if(main == "multiply")
                {
                    int index1 = int.Parse(tokens[1]);
                    int index2 = int.Parse(tokens[2]);
                    inputArray[index1] *= inputArray[index2];
                }
                else if(main == "decrease")
                {
                    for(int i =0; i<inputArray.Length; i++)
                    {
                        inputArray[i]--;
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", inputArray));
        }
    }
}
