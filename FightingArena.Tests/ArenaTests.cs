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
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void WarriorsGetterShouldWorkCorrectly()
        {
            Assert.That(arena.Warriors, Is.EqualTo(new Arena().Warriors));
        }

        [Test]
        public void CountGetterShouldWorkCorrectly()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollMethodShouldThrowWithExistentWarrior()
        {
            arena.Enroll(new Warrior("name", 10, 20));
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("name", 10, 20)));
        }

        [Test]
        public void FightMethodWithNonExistentAttackerOrDefenderShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("attacker", "defender"));
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            arena.Enroll(new Warrior("defender", 20, 35));
            arena.Enroll(new Warrior("attacker", 10, 50));
            arena.Fight("attacker", "defender");

            Assert.That(arena.Warriors.First().HP, Is.EqualTo(25));
        }
    }
}
