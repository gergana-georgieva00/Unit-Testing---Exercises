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

        [Test]
        public void MakeGetterWorksCorrectly()
        {
            Assert.That(car.Make, Is.EqualTo("make"));
        }

        [Test]
        public void ModelCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "", 10, 20));
        }


    }
}