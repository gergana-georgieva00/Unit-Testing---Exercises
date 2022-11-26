namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        //[Test]
        //public void ArrayCapcityMustBe16IntegersLongOtherwiseThrow()
        //{
        //    Database db = new Database(new int[20]);
        //    Assert.Throws<InvalidOperationException>(() => db.Count.Equals(16));
        //    Assert.That(db.Count, Is.EqualTo(16), );
        //}

        [Test]
        public void AddMethodWithFullArrayShouldThrow()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        }

        [Test]
        public void AddMethodShouldAddElementAtTheNextFreeCell()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5 });
            db.Add(6);
            Assert.That(db.Count, Is.EqualTo(6), "Database count increases with new element added");
        }

        [Test]
        public void RemoveMethodShouldThrowOnEmptyArray()
        {
            Database db = new Database(new int[0]);
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5 });
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(4), "Database count decreases with removing element");
        }

        //[Test]
        //public void ConstructorShouldTakeIntegersOnly()
        //{
        //    var chars = new char[] { 'a', 'b' };
        //    Assert.Throws<InvalidOperationException>(() => new Database(chars));
        //}

        [Test]
        public void FetchMethodShouldReturnTheElementsAsAnArray()
        {
            Database db = new Database(new int[] { 1, 2, 3, 4, 5 });
            var resultArray = new int[5];
            Assert.That(resultArray = db.Fetch(), Is.EqualTo(new int[] { 1, 2, 3, 4, 5 }), "Fetch method should return database as an array.");
        }
    }
}
