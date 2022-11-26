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

        [Test]
        public void AddMethodWithFilledcapacityThrow()
        {
            db.Add(new Person(1, "a"));
            db.Add(new Person(2, "b"));
            db.Add(new Person(3, "c"));
            db.Add(new Person(4, "d"));
            db.Add(new Person(5, "e"));
            db.Add(new Person(6, "f"));
            db.Add(new Person(7, "g"));
            db.Add(new Person(8, "h"));
            db.Add(new Person(9, "i"));
            db.Add(new Person(10, "j"));
            db.Add(new Person(11, "k"));
            db.Add(new Person(12, "l"));
            db.Add(new Person(13, "m"));
            db.Add(new Person(14, "n"));
            db.Add(new Person(15, "o"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(123, "User")));
        }

        [Test]
        public void RemoveMethodOnEmptyShouldThrow()
        {
            db = new Database(new Person[0]);
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void RemoveMethodShouldWorkCorrectly()
        {
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(0), "Database count decreases with removing element");
        }

        [Test]
        public void FindByUsernameWithNullOrEmpryInputShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(""));
        }

        [Test]
        public void FindByUsernameWithNonExistentUsernameShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("User"));
        }

        [Test]
        public void FindByUsernameReturnsCorrectObject()
        {
            Person result = db.FindByUsername("Username");
            Person expected = new Person(1234567890, "Username");

            Assert.That(result.UserName, Is.EqualTo(expected.UserName));
            Assert.That(result.Id, Is.EqualTo(expected.Id));
        }
    }
}