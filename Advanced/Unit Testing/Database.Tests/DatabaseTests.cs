namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void Test_CountOfData()
        {
            Database database = new Database(0,1,2,3,4,5,6);

            Assert.That(database.Count, Is.EqualTo(7));
        }

        [Test]
        public void Test_AddNewElement()
        {
            Assert.That(() =>
            {
                Database database = new Database(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
                database.Add(16);
            }, Throws.InvalidOperationException);

        }


        [Test]
        public void Test_ConstrcutorOverflow()
        {
            Assert.That(() =>
            {
                Database database = new Database(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
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
            Database database = new Database(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(15));
        }


        [Test]
        public void Test_FetchArraySize()
        {
            Database database = new Database(1, 2, 3);
            int[] fetchArray = database.Fetch();

            Assert.That(fetchArray.Length, Is.EqualTo(database.Count));
        }
    }
}
