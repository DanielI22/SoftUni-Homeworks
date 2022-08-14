namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void setup()
        {
            aquarium = new Aquarium("Test", 5);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.IsNotNull(aquarium);
            Assert.That(aquarium.Name, Is.EqualTo("Test"));
            Assert.That(aquarium.Capacity, Is.EqualTo(5));
        }

        [Test]
        public void NameInvalidTest()
        {
            Assert.That(() =>
            {
                var aquarium = new Aquarium("", 5);

            }, Throws.ArgumentNullException);
        }

        [Test]
        public void CapInvalidTest()
        {
            Assert.That(() =>
            {
                var aquarium = new Aquarium("Test", -5);

            }, Throws.ArgumentException);
        }

        [Test]
        public void CountTestAd()
        {
            aquarium.Add(new Fish("George"));
            aquarium.Add(new Fish("George2"));
            Assert.That(aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void InvalidAddTest()
        {
            Assert.That(() =>
            {
                aquarium.Add(new Fish("George"));
                aquarium.Add(new Fish("George2"));
                aquarium.Add(new Fish("George3"));
                aquarium.Add(new Fish("George4"));
                aquarium.Add(new Fish("George6"));
                aquarium.Add(new Fish("George5"));
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void InvalidRemoveTest()
        {
            Assert.That(() =>
            {
                aquarium.Add(new Fish("George"));
                aquarium.Add(new Fish("George2"));
                aquarium.Add(new Fish("George3"));
                aquarium.RemoveFish("Peter");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveFishTest()
        {
            Fish fish = new Fish("George");
            Fish fish2 = new Fish("George2");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.RemoveFish("George");

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void SellFishTestAvailability()
        {
            Fish fish = new Fish("George");
            Fish fish2 = new Fish("George2");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            aquarium.SellFish("George");
            Assert.That(fish.Available, Is.False);
        }

        [Test]
        public void SellFishTestReturn()
        {
            Fish fish = new Fish("George");
            Fish fish2 = new Fish("George2");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            Assert.That(fish, Is.EqualTo(aquarium.SellFish("George")));
        }

        [Test]
        public void InvalidSellTest()
        {
            Assert.That(() =>
            {
                aquarium.Add(new Fish("George"));
                aquarium.Add(new Fish("George2"));
                aquarium.Add(new Fish("George3"));
                aquarium.SellFish("Peter");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void ReportTest()
        {
            aquarium.Add(new Fish("George"));
            aquarium.Add(new Fish("Peter"));
            aquarium.Add(new Fish("Smith"));
            var actualReport = aquarium.Report();
            var expectedReport = "Fish available at Test: George, Peter, Smith";
            Assert.That(actualReport, Is.EqualTo(expectedReport));
        }
    }
}
