using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
        //int N = int.Parse(Console.ReadLine());
        //List<Car> cars = new List<Car>();
        //for (int i = 0; i < N; i++)
        //{
        //    List<Tyre> tyresList = new List<Tyre>();
        //    string[] carInput = Console.ReadLine().Split();

        //    string model = carInput[0];
        //    int engineSpeed = int.Parse(carInput[1]);
        //    int enginePower = int.Parse(carInput[2]);
        //    int cargoWeight = int.Parse(carInput[3]);
        //    string cargoType = carInput[4];

        //    Engine currentEngine = new Engine(engineSpeed, enginePower);

        //    Cargo currentCargo = new Cargo(cargoType, cargoWeight);

        //    double tyre1Pressure = double.Parse(carInput[5]);
        //    int tyre1Age = int.Parse(carInput[6]);

        //    double tyre2Pressure = double.Parse(carInput[7]);
        //    int tyre2Age = int.Parse(carInput[8]);

        //    double tyre3Pressure = double.Parse(carInput[9]);
        //    int tyre3Age = int.Parse(carInput[10]);

        //    double tyre4Pressure = double.Parse(carInput[11]);
        //    int tyre4Age = int.Parse(carInput[12]);


        //    tyresList.Add(new Tyre(tyre1Age, tyre1Pressure));
        //    tyresList.Add(new Tyre(tyre2Age, tyre2Pressure));
        //    tyresList.Add(new Tyre(tyre3Age, tyre3Pressure));
        //    tyresList.Add(new Tyre(tyre4Age, tyre4Pressure));

        //    Car currentCar = new Car(model, currentEngine, currentCargo, tyresList);

        //    cars.Add(currentCar);
        //}
        //string nextCommand = Console.ReadLine();

        //if (nextCommand == "fragile")
        //{
        //    foreach (Car car in cars)
        //    {
        //        if(car.Cargo.Type == "fragile" && car.Tyres.Any(tyre => tyre.Pressure < 1))
        //        {
        //            Console.WriteLine(car.Model);
        //        }
        //    }
        //}

        //if (nextCommand == "flammable")
        //{
        //    foreach (Car car in cars)
        //    {
        //        if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
        //        {
        //            Console.WriteLine(car.Model);
        //        }
        //    }
        //}

                int n = int.Parse(Console.ReadLine());
                Dictionary<string, Engine> enginesCollection = new Dictionary<string, Engine>();

                for (int i = 0; i < n; i++)
                {
                    string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string engineModel = engineInfo[0];
                    int power = int.Parse(engineInfo[1]);
                    Engine engine = new Engine();

                    if (engineInfo.Length == 3)
                    {
                        if (char.IsDigit(engineInfo[2][0]))
                        {
                            int displacement = int.Parse(engineInfo[2]);
                            engine = new Engine(engineModel, power, displacement);

                        }
                        else
                        {
                            string efficiency = engineInfo[2];
                            engine = new Engine(engineModel, power, efficiency);
                        }
                    }
                    else if (engineInfo.Length == 4)
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        string efficiency = engineInfo[3];
                        engine = new Engine(engineModel, power, displacement, efficiency);
                    }
                    else
                    {
                        engine = new Engine(engineModel, power);

                    }
                    //"{model} {power} {displacement} {efficiency}"
                    enginesCollection.Add(engineModel, engine);

                }

                int m = int.Parse(Console.ReadLine());

                List<Car> carsList = new List<Car>();

                for (int i = 0; i < m; i++)
                {
                    string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string carModel = carInfo[0];
                    string carEngine = carInfo[1];
                    Engine engine = enginesCollection[carEngine];

                    if (carInfo.Length == 3)
                    {
                        if (char.IsDigit(carInfo[2][0]))
                        {
                            int carWeight = int.Parse(carInfo[2]);
                            Car car = new Car(carModel, engine, carWeight);
                            carsList.Add(car);

                        }
                        else
                        {
                            string carColor = carInfo[2];
                            Car car = new Car(carModel, engine, carColor);
                            carsList.Add(car);
                        }
                    }
                    else if (carInfo.Length == 4)
                    {
                        int carWeight = int.Parse(carInfo[2]);
                        string carColor = carInfo[3];

                        Car car = new Car(carModel, engine, carWeight, carColor);
                        carsList.Add(car);
                    }
                    else
                    {
                        Car car = new Car(carModel, engine);
                        carsList.Add(car);
                    }
                }

                foreach (var car in carsList)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
    }