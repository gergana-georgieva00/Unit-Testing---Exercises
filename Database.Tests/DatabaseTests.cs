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
    }
}
