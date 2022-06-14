using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();
            while (input != "END")
            {
                string[] person = input.Split(' ');
                Person currentPerson = new Person(person[0], int.Parse(person[1]), person[2]);
                persons.Add(currentPerson);

                input = Console.ReadLine();
            }

            int n = int.Parse(Console.ReadLine());

            int matches = 0;
            int notMatches = 0;

            foreach (Person person in persons)
            {
                if (person.CompareTo(persons[n-1])==0)
                {
                    matches++;
                }
                else
                {
                    notMatches++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {notMatches} {persons.Count}");
            }
        }
    }
}
