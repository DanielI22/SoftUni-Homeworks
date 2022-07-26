namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void Test_Constructors()
        {
            Car car = new Car("BMW", "X5", 15, 100);
            Assert.IsNotNull(car);
            Assert.That(car.FuelAmount, Is.EqualTo(0));
            Assert.That(car.Make, Is.EqualTo("BMW"));
            Assert.That(car.Model, Is.EqualTo("X5"));
            Assert.That(car.FuelConsumption, Is.EqualTo(15));
            Assert.That(car.FuelCapacity, Is.EqualTo(100));
        }
        [Test]
        public void Test_EmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "X5", 15, 100);

            });
        }
        [Test]
        public void Test_NullMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "X5", 15, 100);

            });
        }

        [Test]
        public void Test_EmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "", 15, 100);

            });
        }
        [Test]
        public void Test_NullModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", null, 15, 100);

            });
        }

        [Test]
        public void Test_NegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", -1, 100);

            });
        }


        [Test]
        public void Test_ZeroFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", 0, 100);

            });
        }

        [Test]
        public void Test_NegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", 15, -89);

            });
        }


        [Test]
        public void Test_ZeroFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", 15, 0);

            });
        }

        [Test]
        public void Test_Refuel()
        {
            Car car = new Car("BMW", "X5", 15, 100);
            car.Refuel(50);
            Assert.That(car.FuelAmount.Equals(50));
        }

        [Test]
        public void Test_RefuelWithNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", 15, 100);
                car.Refuel(-1);

            });
        }

        [Test]
        public void Test_RefuelOverCapacity()
        {
            Car car = new Car("BMW", "X5", 15, 100);
            car.Refuel(200);
            Assert.That(car.FuelAmount.Equals(car.FuelCapacity));
        }

        [Test]
        public void Test_RefuelWithZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("BMW", "X5", 15, 100);
                car.Refuel(0);

            });
        }
        [Test]
        public void TestDrivingCorrectly()
        {
            Car car = new Car("BMW", "X5", 15, 100);
            car.Refuel(10);
            car.Drive(10);
            double expectedFuel = 8.5;

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [Test]
        public void TestDrivingTooMuchDistance()
        {
            Car car = new Car("BMW", "X5", 15, 100);
            car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(10);
            });
        }
    }
}