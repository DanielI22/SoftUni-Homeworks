using System;

namespace TupleExample
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string fullName = input[0] + " " + input[1];
            string address = input[2];
            string town = input[3];

            Threeuple<string,string,string> tuple1= new Threeuple<string, string, string>(fullName, address, town);


            string[] input2 = Console.ReadLine().Split(' ');
            string name = input2[0]; 
            int beer = int.Parse(input2[1]);
            string drunk = input2[2];

            bool flag;
            if (drunk == "drunk")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(name, beer, flag);


            string[] input3 = Console.ReadLine().Split(' ');
            string n = input3[0];
            double m = double.Parse(input3[1]);
            string bankName = input3[2];

            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(n, m, bankName);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);

        }
    }
}
