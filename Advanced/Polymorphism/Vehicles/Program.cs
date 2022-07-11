using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if(tokens[0] == "Drive")
                {
                    if(tokens[1] == "Car")
                    {
                        car.Drive(double.Parse(tokens[2]));
                    }
                    else if(tokens[1] == "Truck")
                    {
                        truck.Drive(double.Parse(tokens[2]));
                    }
                    else if (tokens[1] == "Bus")
                    {
                        bus.Drive(double.Parse(tokens[2]));
                    }
                }
                else if(tokens[0] == "Refuel")
                {
                    if (tokens[1] == "Car")
                    {
                        car.Refuel(double.Parse(tokens[2]));
                    }
                    else if (tokens[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(tokens[2]));
                    }
                    else if (tokens[1] == "Bus")
                    {
                        bus.Refuel(double.Parse(tokens[2]));
                    }
                }
                else if(tokens[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(tokens[2]));
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
