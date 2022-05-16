using System;
using System.Collections.Generic;

namespace _6._Vehicle_Catalogue
{
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public override string ToString()
        {
            return   $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
                                $"Model: {this.Model}{Environment.NewLine}" +
                                $"Color: {this.Color}{Environment.NewLine}" +
                                $"Horsepower: {this.HorsePower}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] tokens = command.Split();
                Vehicle vehicle = new Vehicle(tokens[0], tokens[1], tokens[2], int.Parse(tokens[3]));
                vehicleList.Add(vehicle);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while(command != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in vehicleList)
                {
                    if(vehicle.Model == command)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                command = Console.ReadLine();
            }

            double sumCar = 0;
            int brC = 0;
            double sumTruck = 0;
            int brT = 0;
            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.Type == "car")
                {
                    sumCar += vehicle.HorsePower;
                    brC++;
                }

                if(vehicle.Type == "truck")
                {
                    sumTruck += vehicle.HorsePower;
                    brT++;
                }
            }

            if(brC == 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {(sumCar / brC):f2}.");
            }
            if (brT == 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {(sumTruck / brT):f2}.");
            }
        }
    }
}
