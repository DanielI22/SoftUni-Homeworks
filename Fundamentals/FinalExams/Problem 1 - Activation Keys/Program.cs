using System;

namespace Problem_1___Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawKey = Console.ReadLine();
            string command = Console.ReadLine();

            while(command != "Generate")
            {
                string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                string mainCom = tokens[0];

                if(mainCom == "Contains")
                {
                    string substring = tokens[1];
                    if (rawKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if(mainCom == "Flip")
                {
                    string upOrLow = tokens[1];
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);

                    string subStr = rawKey.Substring(startIndex, endIndex - startIndex);

                    if(upOrLow == "Upper")
                    {
                        rawKey = rawKey.Replace(subStr, subStr.ToUpper());
                    }
                    else if(upOrLow == "Lower")
                    {
                        rawKey = rawKey.Replace(subStr, subStr.ToLower());
                    }
                    Console.WriteLine(rawKey);
                }
                else if(mainCom == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    rawKey = rawKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawKey);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {rawKey}");
        }
    }
}
