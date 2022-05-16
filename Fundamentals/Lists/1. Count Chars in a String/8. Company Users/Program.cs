using System;
using System.Collections.Generic;

namespace _8._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string companyName = command.Split(" -> ")[0];
                string employeeId = command.Split(" -> ")[1];
                if (company.ContainsKey(companyName))
                {
                    if(!company[companyName].Contains(employeeId))
                    {
                      company[companyName].Add(employeeId);
                    }
                }
                else
                {
                    company.Add(companyName, new List<string> { employeeId });
                }
                command = Console.ReadLine();
            }
            foreach (var item in company)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine("-- " + String.Join("\n-- ", item.Value));
            }
        }
    }
}
