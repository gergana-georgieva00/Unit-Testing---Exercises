namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("make", "model", 10, 20);
        }

        [Test]
        public void MakeCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("", "model", 10, 20));
        }
    }
}