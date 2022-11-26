namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

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
    }
}
