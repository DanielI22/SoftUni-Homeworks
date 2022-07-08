using System;

namespace Telephony
{
    public class StartUp
    {
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        static bool IsLettersOnly(string str)
        {
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                    return false;
            }

            return true;
        }
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] phones = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            foreach (var item in phones)
            {
                if(!IsDigitsOnly(item))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                if(item.Length == 10)
                {
                    Console.WriteLine(smartphone.callNumber(item));
                }

                else if(item.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.callNumber(item));
                }
            }

            foreach (var item in urls)
            {
                if(!IsLettersOnly(item))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                Console.WriteLine(smartphone.browse(item));
            }
        }
    }
}
