namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {

        [Test]
        public void Test_Constructor()
        {
            Warrior warrior = new Warrior("Will", 20, 50);
            Assert.NotNull(warrior);
        }

        [Test]
        public void Test_NameValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior newWarrior = new Warrior("", 20, 10);
            });
        }

        [Test]
        public void Test_DamageValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior newWarrior = new Warrior("Will", 0, 10);
            });
        }


        [Test]
        public void Test_HpValidation()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior newWarrior = new Warrior("Will", 30, -20);
            });
        }

        [Test] 
        public void Test_AttackSuccess()
        {
            Warrior warrior = new Warrior("Will", 20, 50);
            Warrior warrior2 = new Warrior("Ben", 30, 80);
            warrior.Attack(warrior2);

            Assert.That(warrior2.HP, Is.EqualTo(60));
            Assert.That(warrior.HP, Is.EqualTo(20));

        }

        [Test]
        public void Test_AttackAndKill()
        {
            Warrior warrior = new Warrior("Will", 60, 50);
            Warrior warrior2 = new Warrior("Ben", 30, 50);
            warrior.Attack(warrior2);

            Assert.That(warrior2.HP, Is.EqualTo(0));
            Assert.That(warrior.HP, Is.EqualTo(20));

        }

        [Test]
        public void Test_AttackOnLowHp()
        {
            Warrior warrior = new Warrior("Will", 60, 20);
            Warrior warrior2 = new Warrior("Ben", 30, 50);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warrior2);
            });
        }

        [Test]
        public void Test_AttackLowHpEnemy()
        {
            Warrior warrior = new Warrior("Will", 60, 80);
            Warrior warrior2 = new Warrior("Ben", 30, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warrior2);
            });
        }

        [Test]
        public void Test_AttackTooStrongEnemy()
        {
            Warrior warrior = new Warrior("Will", 60, 80);
            Warrior warrior2 = new Warrior("Ben", 90, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warrior2);
            });
        }
    }
}