namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;
        private Person person;

        [SetUp]
        public void Setup()
        {
            person = new Person(1234567890, "Username");
            db = new Database(new Person[] { person });
        }

        //[Test]
        //public void RemoveMethodShouldWorkCorrectly()
        //{
        //    Database db = new Database(new int[] { 1, 2, 3, 4, 5 });
        //    db.Remove();
        //    Assert.That(db.Count, Is.EqualTo(4), "Database count decreases with removing element");
        //}

        //[Test]
        //public void ConstructorShouldTakeIntegersOnly()
        //{
        //    var chars = new char[] { 'a', 'b' };
        //    Assert.Throws<InvalidOperationException>(() => new Database(chars));
        //}

        [Test]
        public void AddMethodWithExistantUsernameShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(123, "Username")));
        }

        [Test]
        public void AddMethodWithExistantIdShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(1234567890, "User")));
        }
    }
}