using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mydic = new Dictionary<string, int>();
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var item in participants)
            {
                mydic.Add(item, 0);
            }

            string input = Console.ReadLine();

            while(input != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int sum = 0;
                Regex regex1 = new Regex("[A-Za-z]");
                Regex regex2= new Regex(@"\d");
                MatchCollection matches1 = regex1.Matches(input);
                MatchCollection matches2 = regex2.Matches(input);
                foreach (Match item in matches1)
                {
                    name.Append(item);
                }
                foreach (Match item in matches2)
                {
                    sum += int.Parse(item.Value);
                }
                if(mydic.ContainsKey(name.ToString()))
                {
                    mydic[name.ToString()] += sum;
                }

                input = Console.ReadLine();
            }
            Dictionary<string, int> finalDic = mydic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x=>x.Value);
            List<string> finalList = finalDic.Keys.ToList();
            Console.WriteLine("1st place: " + finalList[0]);
            Console.WriteLine("2nd place: " + finalList[1]);
            Console.WriteLine("3rd place: " + finalList[2]);
        }
    }
}
