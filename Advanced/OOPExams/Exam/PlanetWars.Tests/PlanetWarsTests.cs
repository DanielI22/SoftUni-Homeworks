using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            [SetUp]
            public void setup()
            {
                planet = new Planet("Test", 100);
                planet.AddWeapon(new Weapon("Wep", 20, 5));
            }

            [Test]
            public void contructorSetterTestPlanet()
            {
                Planet planet = new Planet("Test", 100);
                Assert.IsNotNull(planet);
                Assert.That(planet.Name, Is.EqualTo("Test"));
                Assert.That(planet.Budget, Is.EqualTo(100));
            }

            [Test]
            public void contructorSetterTestWeapon()
            {
                Weapon weapon = new Weapon("Test", 10, 5);
                Assert.IsNotNull(weapon);
                Assert.That(weapon.Name, Is.EqualTo("Test"));
                Assert.That(weapon.Price, Is.EqualTo(10));
                Assert.That(weapon.DestructionLevel, Is.EqualTo(5));
            }

            [Test]
            public void InvalidNameTest()
            {
                Assert.That(() =>
                {
                    Planet planet = new Planet("", 100);

                }, Throws.ArgumentException);

            }

            [Test]
            public void InvalidBudgetTest()
            {
                Assert.That(() =>
                {
                    Planet planet = new Planet("Test", -10);

                }, Throws.ArgumentException);
            }

            [Test]
            public void InvalidWeaponPriceTest()
            {
                Assert.That(() =>
                {
                    Weapon weapon = new Weapon("Test", -10, 5);

                }, Throws.ArgumentException);
            }

            [Test]
            public void WeaponDestructionLevel()
            {
                Weapon weapon = new Weapon("Test", 10, 5);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
            }

            [Test]
            public void WeaponNuclearTrue()
            {
                Weapon weapon = new Weapon("Test", 10, 15);
                Assert.That(weapon.IsNuclear, Is.True);
            }

            [Test]
            public void WeaponNuclearFalse()
            {
                Weapon weapon = new Weapon("Test", 10, 2);
                Assert.That(weapon.IsNuclear, Is.False);
            }
            [Test]
            public void PlanetCollection()
            {
                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }

            [Test]
            public void PlanetMilitrayPowerTest()
            {
                planet.AddWeapon(new Weapon("Wep2", 20, 5));
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(10));
            }

            [Test]
            public void ProfitTest()
            {
                planet.Profit(20);
                Assert.That(planet.Budget, Is.EqualTo(120));
            }

            [Test]
            public void SpentFundTest()
            {
                planet.SpendFunds(10);
                Assert.That(planet.Budget, Is.EqualTo(90));
            }

            [Test]
            public void SpentInvalidFundTest()
            {
                Assert.That(() =>
                {
                    planet.SpendFunds(110);

                }, Throws.InvalidOperationException);
            }

            [Test]
            public void AddWeaponTest()
            {
                planet.AddWeapon(new Weapon("Wep2", 10, 10));
                Assert.That(planet.Weapons.Count, Is.EqualTo(2));
            }

            [Test]
            public void InvalidAddTest()
            {
                Assert.That(() =>
                {
                    planet.AddWeapon(new Weapon("Wep", 10, 10));

                }, Throws.InvalidOperationException);
            }

            [Test]
            public void RemoveWeaponTest()
            {
                planet.AddWeapon(new Weapon("Wep2", 10, 10));
                planet.RemoveWeapon("Wep2");
                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }


            [Test]
            public void RemoveWeaponTest2()
            {
                planet.AddWeapon(new Weapon("Wep2", 10, 10));
                planet.RemoveWeapon("Wep3");
                Assert.That(planet.Weapons.Count, Is.EqualTo(2));
            }

            [Test]
            public void UpgradeWeaponTest()
            {
                Weapon weapon = new Weapon("TestWep", 10, 5);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("TestWep");
                Assert.That(weapon.DestructionLevel, Is.EqualTo(6));
            }

            [Test]
            public void InvalidUpgradeTest()
            {
                Assert.That(() =>
                {
                    planet.UpgradeWeapon("Invalid");

                }, Throws.InvalidOperationException);
            }

            [Test]
            public void DestructOpponentTest()
            {
                Planet planet2 = new Planet("Test2", 100);
                planet2.AddWeapon(new Weapon("Wep2", 10, 2));
                var expectedMessege = $"Test2 is destructed!";
                var actualMessege = planet.DestructOpponent(planet2);
                Assert.That(expectedMessege, Is.EqualTo(actualMessege));
            }

            [Test]
            public void InvalidDestructTest()
            {
                Assert.That(() =>
                {
                    Planet planet2 = new Planet("Test2", 100);
                    planet2.AddWeapon(new Weapon("Wep2", 10, 10));
                    planet.DestructOpponent(planet2);

                }, Throws.InvalidOperationException);
            }
        }
    }
}
