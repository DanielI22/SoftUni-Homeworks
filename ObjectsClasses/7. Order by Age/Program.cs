using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int age { get; set; }

        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {age} years old.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Person> people = new List<Person>();
            while(command != "End")
            {
                string[] tokens = command.Split();
                string name = tokens[0];
                string ID = tokens[1];
                int age = int.Parse(tokens[2]);

                Person myPerson = new Person(name, ID, age);
                bool personExist = false;
                foreach (Person person in people)
                {
                    if(person.ID == ID)
                    {
                        personExist = true;
                        person.Name = name;
                        person.age = age;
                    }
                }

                if(!personExist)
                {
                    people.Add(myPerson);
                }

                command = Console.ReadLine();
            }

            List<Person> orderedList = people.OrderBy(x => x.age).ToList();
            Console.WriteLine(String.Join("\n",orderedList));
        }
    }
}
