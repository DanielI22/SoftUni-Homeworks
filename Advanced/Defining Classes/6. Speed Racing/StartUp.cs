using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> carList = new List<Car>();
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelRate = double.Parse(input[2]);

                Car currentCar = new Car(model, fuelAmount, fuelRate);
                carList.Add(currentCar);

            }
            string command = Console.ReadLine();
            while(command  != "End")
            {
                string[] tokens = command.Split(' ');
                string model = tokens[1];
                int km = int.Parse(tokens[2]);

                carList.First(car => car.Model == model).MoveCar(km);

                command = Console.ReadLine();
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Travelleddistance}");
            }
        }
    }
}
