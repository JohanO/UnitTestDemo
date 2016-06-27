using NUnit.Framework;
using MyProject.Domain;
using ExpectedObjects;

namespace MyProject.Test
{
    [TestFixture()]
    public class MyCustomerHandlerTests
    {
        private MyCustomerHandler _underTest;

        [SetUp]
        public void SetUp()
        {
            _underTest = new MyCustomerHandler();
        }

        [Test]
        public void CreateCustomer_ShouldReturnNewCustomer()
        {
            // Arrange
            var name = "Donald Duck";
            var street = "1313 Webfoot Walk";
            var city = "Duckburg";

            // Act
            var actual = _underTest.CreateCustomer(name, street, city);

            // Assert
            Assert.That(actual.Id, Is.EqualTo(1));
            Assert.That(actual.Name, Is.EqualTo(name));
            Assert.That(actual.Address.Street, Is.EqualTo(street));
            Assert.That(actual.Address.City, Is.EqualTo(city));
        }

        [Test]
        public void CreateCustomer_ShouldReturnNewCustomer_UsingExpectedObjects()
        {
            // Arrange
            var name = "Scrooge McDuck";
            var street = "Money Bin, Killmotor Hill";
            var city = "Duckburg";

            // Act
            var actual = _underTest.CreateCustomer(name, street, city);

            // Assert
            var expected = new Customer
            {
                Id = 1,
                Name = name,
                Address = new Address { Street = street, City = city }
            }.ToExpectedObject();
            expected.ShouldEqual(actual);
        }
    }
}