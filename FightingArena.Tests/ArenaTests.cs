namespace FightingArena.Tests
{
    using NUnit.Framework;

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
    }
}
