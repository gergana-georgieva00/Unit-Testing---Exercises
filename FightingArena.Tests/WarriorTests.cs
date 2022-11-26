namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("warrior", 10, 20);
        }

        [Test]
        public void NameCannotBeNullOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior(" ", 10, 20));
        }
    }
}