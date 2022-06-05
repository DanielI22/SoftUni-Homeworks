using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for(int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');

            //    string name = input[0];
            //    int age = int.Parse(input[1]);

            //    Person person = new Person(name, age);
            //    family.AddMember(person);
            //}

            //Person oldest = family.GetOldestMember();

            //Console.WriteLine(oldest.Name + " " + oldest.Age);


            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }


            List<Person> sortedList = new List<Person>();
            sortedList = family.People.Where(member => member.Age > 30).OrderBy(member => member.Name).ToList();

            foreach (Person person in sortedList)
            {
                Console.WriteLine(person.Name + " - " + person.Age);
            }
         }
    }
}
