namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Person[] persons = new Person[] {new Person(1, "1"), new Person(2, "2")};


        [Test]
        public void Test_CountOfData()
        {
            Database database = new Database(persons);

            Assert.That(database.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_AddNewElementWhenFull()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                for(int i = 0; i < 16; i++)
                {
                    database.Add(new Person(i, (char)i + "a"));
                }
                database.Add(new Person(111111, "Exce"));
            }, Throws.InvalidOperationException);

        }


        [Test]
        public void Test_ConstructorOverflow()
        {
            Assert.That(() =>
            {

                Database database = new Database();
                for (int i = 0; i < 17; i++)
                {
                    database.Add(new Person(i, (char)i + "a"));
                }
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Test_RemoveElementWhenEmpty()
        {
            Assert.That(() =>
            {
                Database database = new Database();
                database.Remove();
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Test_RemoveElementWhenFull()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, (char)i + "a"));
            }
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(15));
        }


        [Test]
        public void Test_AddSameUsername()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                database.Add(new Person(3, "1"));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void Test_AddSameId()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                database.Add(new Person(1, "3"));
            }, Throws.InvalidOperationException);

        }

        [Test]
        public void Test_FindByUsername()
        {
            Database database = new Database(persons);
            Person user = database.FindByUsername("1");

            Assert.That(user.Id, Is.EqualTo(1));
            Assert.That(user.UserName, Is.EqualTo("1"));
        }

        [Test]
        public void Test_FindByUsernameWhenIsNotPresent()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                Person user = database.FindByUsername("3");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Test_FindByUsernameWhenUserIsNull()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                Person user = database.FindByUsername(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void Test_FindByUsernameWhenCaseNotMatch()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                database.Add(new Person(3, "Will"));
                Person user = database.FindByUsername("will");
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Test_FindById()
        {
            Database database = new Database(persons);
            Person user = database.FindById(1);

            Assert.That(user.Id, Is.EqualTo(1));
            Assert.That(user.UserName, Is.EqualTo("1"));
        }

        [Test]
        public void Test_FindByIdIfNotPresent()
        {
            Assert.That(() =>
            {
                Database database = new Database(persons);
                Person user = database.FindById(3);
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void Test_FindByIdWhenNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Database database = new Database(persons);
                Person user = database.FindById(-3);
            });
        }
    } 
}