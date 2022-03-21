using System;

namespace Problem_1___SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stud1 = int.Parse(Console.ReadLine());
            int stud2 = int.Parse(Console.ReadLine());
            int stud3 = int.Parse(Console.ReadLine());
            int studentsAll = int.Parse(Console.ReadLine());

            int oneHour = stud1 + stud2 + stud3;
            int time = (int)Math.Ceiling(studentsAll / (double)oneHour);
            for(int i = 1; i<=time; i++)
            {
                if(i % 4 == 0)
                {
                   time++;
                }
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
