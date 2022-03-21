using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                Student myStudent = new Student(command[0], command[1], double.Parse(command[2]));
                studentsList.Add(myStudent);
            }
            List<Student> orderedList = studentsList.OrderBy(student => student.Grade).Reverse().ToList();
            foreach (var student in orderedList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
