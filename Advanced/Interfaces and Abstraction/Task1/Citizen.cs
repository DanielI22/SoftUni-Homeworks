﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }

        public Citizen(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Citizen(string name, int age, string id, string birthdate) : this(name, age)
        {
            Id = id;
            Birthdate = birthdate;
        }
    }
}
