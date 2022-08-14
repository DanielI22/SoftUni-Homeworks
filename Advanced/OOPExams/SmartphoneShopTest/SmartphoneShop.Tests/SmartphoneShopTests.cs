using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Shop shop;

        [Test]
        public void ConstructorShouldWorkProperply()
        {
            Shop shop = new Shop(5);
            Assert.That(shop, Is.Not.Null);
        }

        [Test]
        public void CapacityValidationTest()
        {
            Shop shop = new Shop(10);

            Assert.That(shop.Capacity, Is.EqualTo(10));
        }
        [Test]
        public void InvalidCapacityTest()
        {
            Assert.That(() =>
            {
                Shop shop = new Shop(-10);
            }, Throws.ArgumentException, "Invalid capacity.");
        }
        [Test]
        public void PhonesCountTest()
        {
            Shop shop = new Shop(5);
            shop.Add(new Smartphone("Test", 20));

            Assert.That(shop.Count, Is.EqualTo(1));
        }
        [Test]
        public void PhonesExistTest()
        {
            Assert.That(() =>
            {
                Shop shop = new Shop(5);
                shop.Add(new Smartphone("Test", 20));
                shop.Add(new Smartphone("Test", 20));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void CapacityReachedTest()
        {
            Assert.That(() =>
            {
                Shop shop = new Shop(1);
                shop.Add(new Smartphone("Test", 20));
                shop.Add(new Smartphone("Test2", 30));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void RemovePhoneTest()
        {
            var shop = new Shop(2);
            shop.Add(new Smartphone("Test", 20));
            shop.Remove("Test");

            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveNonExistingPhoneTest()
        {
            Assert.That(() =>
            {
                var shop = new Shop(2);
                shop.Add(new Smartphone("Test", 20));
                shop.Remove("Test2");
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void TestTestPhone()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Test", 50);
            shop.Add(smartphone);
            shop.TestPhone("Test", 10);
            int expectedBattery = 40;
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(expectedBattery));
        }

        [Test]
        public void TestTestPhone2()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Test", 50);
            shop.Add(smartphone);
            shop.TestPhone("Test", 10);
            shop.TestPhone("Test", 20);
            int expectedBattery = 20;
            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(expectedBattery));
        }

        [Test]
        public void TestInvalidPhone()
        {
            Assert.That(() =>
            {
                var shop = new Shop(2);
                var smartphone = new Smartphone("Test", 50);
                shop.Add(smartphone);
                shop.TestPhone("Test2", 10);
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void TestLowBatteryPhone()
        {
            Assert.That(() =>
            {
                var shop = new Shop(2);
                var smartphone = new Smartphone("Test", 50);
                shop.Add(smartphone);
                shop.TestPhone("Test", 60);
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void TestChargingPhone()
        {
            var shop = new Shop(2);
            var smartphone = new Smartphone("Test", 50);
            shop.Add(smartphone);
            shop.TestPhone("Test", 20);
            shop.ChargePhone("Test");
            var expectedBattery = 50;
            var realBattery = smartphone.CurrentBateryCharge;

            Assert.That(realBattery, Is.EqualTo(expectedBattery));
        }

        [Test]
        public void TestChargingPhoneNotExist()
        {
            Assert.That(() =>
            {
                var shop = new Shop(2);
                var smartphone = new Smartphone("Test", 50);
                shop.Add(smartphone);
                shop.TestPhone("Test", 20);
                shop.ChargePhone("Test2");
            }, Throws.InvalidOperationException);
        }
    }
}