using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tyre
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tyre(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
    }
}
