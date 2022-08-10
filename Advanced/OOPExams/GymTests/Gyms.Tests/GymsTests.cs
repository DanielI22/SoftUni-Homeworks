using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;

        [SetUp]
        public void setupGym()
        {
            gym = new Gym("Test", 5);
        }

        [Test]
        public void ctor_Test()
        {
            Assert.IsNotNull(gym);
            Assert.AreEqual("Test", gym.Name);
            Assert.That(gym.Capacity, Is.EqualTo(5));
        }

        [Test]
        public void IvalidNameTest()
        {
            Assert.That(() =>
            {
                Gym gym = new Gym("", 5);

            }, Throws.ArgumentNullException);
        }

        [Test]
        public void IvalidCap_Test()
        {
            Assert.That(() =>
            {
                Gym gym = new Gym("Test", -5);

            }, Throws.ArgumentException);
        }

        [Test]
        public void AddCount_Test()
        {
            gym.AddAthlete(new Athlete("George"));
            Assert.That(gym.Count, Is.EqualTo(1));
        }
        [Test]
        public void FullGymTest()
        {
            Assert.That(() =>
            {
                gym.AddAthlete(new Athlete("George"));
                gym.AddAthlete(new Athlete("George2"));
                gym.AddAthlete(new Athlete("George3"));
                gym.AddAthlete(new Athlete("George4"));
                gym.AddAthlete(new Athlete("George5"));
                gym.AddAthlete(new Athlete("George6"));

            }, Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveTest()
        {
            gym.AddAthlete(new Athlete("George"));
            gym.RemoveAthlete("George");
            Assert.That(gym.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveTest2()
        {
            gym.AddAthlete(new Athlete("George"));
            gym.AddAthlete(new Athlete("Peter"));
            gym.RemoveAthlete("George");
            Assert.That(gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void InvalidRemoveTest()
        {
            Assert.That(() =>
            {
                gym.AddAthlete(new Athlete("George"));
                gym.RemoveAthlete("George2");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void TestInjury()
        {
            Athlete athlete = new Athlete("George");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("George");
            Assert.That(athlete.IsInjured, Is.True);
        }

        [Test]
        public void TestNotInjury()
        {
            Athlete athlete = new Athlete("George");
            gym.AddAthlete(athlete);
            Assert.That(athlete.IsInjured, Is.False);
        }

        [Test]
        public void TestFakeInjury()
        {
            Assert.That(() =>
            {
                Athlete athlete = new Athlete("George");
                gym.AddAthlete(athlete);
                gym.InjureAthlete("George2");

            }, Throws.InvalidOperationException); 
        }

        [Test]
        public void TestReturnOfInjury()
        {
            Athlete athlete = new Athlete("George");
            gym.AddAthlete(athlete);
            Athlete requested = gym.InjureAthlete("George");
            Assert.That(requested, Is.EqualTo(athlete));
        }

        [Test]
        public void ReportTest()
        {
            Athlete athlete = new Athlete("George");
            Athlete athlete2 = new Athlete("Peter");
            Athlete athlete3 = new Athlete("Spens");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            gym.InjureAthlete("George");

            string expectedReport = "Active athletes at Test: Peter, Spens";
            string actualReport = gym.Report();
            Assert.That(expectedReport, Is.EqualTo(actualReport));
        }

        [Test]
        public void ReportTest2()
        {
            Athlete athlete = new Athlete("George");
            gym.AddAthlete(athlete);


            string expectedReport = "Active athletes at Test: George";
            string actualReport = gym.Report();
            Assert.That(expectedReport, Is.EqualTo(actualReport));
        }

        [Test]
        public void Count2Test()
        {
            gym.AddAthlete(new Athlete("Georeg"));
            gym.AddAthlete(new Athlete("Georeg"));
            gym.AddAthlete(new Athlete("Georeg"));
            Assert.That(gym.Count, Is.EqualTo(3));
        }
    }
}
