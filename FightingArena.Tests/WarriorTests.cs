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

        [Test]
        public void NameGetterWorksCorrectly()
        {
            Assert.That(warrior.Name, Is.EqualTo("warrior"));
        }

        [Test]
        public void DamageCannotBeZeroOrLess()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("warrior", 0, 20));
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("warrior", -1, 20));
        }

        [Test]
        public void DamageGetterWorksCorrectly()
        {
            Assert.That(warrior.Damage, Is.EqualTo(10));
        }

        [Test]
        public void HPCannotBeLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => warrior = new Warrior("warrior", 10, -2));
        }

        [Test]
        public void HPGetterWorksCorrectly()
        {
            Assert.That(warrior.HP, Is.EqualTo(20));
        }

        [Test]
        public void AttackMethodWithLowHPShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("name", 20, 30)));
        }

        [Test]
        public void AttackMethodWithTargetHPLowShouldThrow()
        {
            warrior = new Warrior("warrior", 10, 50);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("name", 20, 30)));
        }

        [Test]
        public void AttackMethodWithWarriorHPLowerThanTargetDamage()
        {
            warrior = new Warrior("warrior", 10, 49);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("name", 50, 35)));
        }

        [Test]
        public void AttackMethodShouldDecreaseHP()
        {
            warrior = new Warrior("warrior", 10, 50);
            warrior.Attack(new Warrior("name", 20, 35));
            Assert.That(warrior.HP, Is.EqualTo(30));
        }

        [Test]
        public void AttackMethodShouldDecreaseTargetHP()
        {
            var target = new Warrior("name", 20, 35);
            warrior = new Warrior("warrior", 10, 50);
            warrior.Attack(target);
            Assert.That(target.HP, Is.EqualTo(25));
        }

        [Test]
        public void AttackMethodShouldMakeTargetHPZero()
        {
            var target = new Warrior("name", 20, 35);
            warrior = new Warrior("warrior", 60, 50);
            warrior.Attack(target);
            Assert.That(target.HP, Is.EqualTo(0));
        }
    }
}