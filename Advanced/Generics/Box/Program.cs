using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> myBox = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                myBox.Elements.Add(double.Parse(Console.ReadLine()));
            }

            double elementForComparison = double.Parse(Console.ReadLine());

            Console.WriteLine(myBox.Count<double>(myBox.Elements, elementForComparison));

        }

    }
}
