namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void Test_EnrollWarrior()
        {
            arena.Enroll(new Warrior("Will", 50, 100));
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Test_EnrollExistingWarrior()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Will", 50, 100));
                arena.Enroll(new Warrior("Will", 50, 100));

            });
        }

        [Test]
        public void CheckIfAttackWorksProperly()
        {
            arena.Enroll(new Warrior("Will", 50, 100));
            arena.Enroll(new Warrior("Ben", 50, 100));
            var attacker = this.arena.Warriors.First(w => w.Name == "Will");
            var defender = this.arena.Warriors.First(w => w.Name == "Ben");

            var expectedHp = defender.HP - attacker.Damage;

            if (expectedHp < 0)
            {
                expectedHp = 0;
            }

            this.arena.Fight("Will", "Ben");

            var actualHp = defender.HP;

            Assert.AreEqual(expectedHp, actualHp);

        }

        [Test]
        public void Test_FightWithInvalidAttacker()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Will", 50, 100));
                arena.Enroll(new Warrior("Ben", 50, 100));
                arena.Fight("Wills", "Ben");
            });
        }

        [Test]
        public void Test_FightWithInvalidDefender()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Will", 50, 100));
                arena.Enroll(new Warrior("Ben", 50, 100));
                arena.Fight("Will", "Bens");
            });
        }
    }
}
