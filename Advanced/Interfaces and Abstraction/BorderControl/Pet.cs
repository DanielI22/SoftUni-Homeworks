using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Pet : IBorn
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
    }
}
