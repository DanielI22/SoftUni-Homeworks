using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for(int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(students.ContainsKey(student))
                {
                    students[student].Add(grade);
                }
                else
                {
                    students[student] = new List<double> { grade };
                }
            }

            var finalDic = students.Where(s => s.Value.Average() >= 4.5);

            foreach (var item in finalDic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
            }
        }
    }
}
