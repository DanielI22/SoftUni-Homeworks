using System;
using System.Collections.Generic;

namespace _6._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string command = Console.ReadLine();
            while(command != "end")
            {
                string courseName = command.Split(" : ")[0];
                string studentName = command.Split(" : ")[1];
                if(courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(studentName);
                }
                else
                {
                    courses.Add(courseName, new List<string> {studentName});
                }
                command = Console.ReadLine();
            }
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                Console.WriteLine("-- " + String.Join("\n-- ", item.Value));
            }
        }
    }
}
