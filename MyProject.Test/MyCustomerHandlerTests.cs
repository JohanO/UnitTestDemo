using FluentAssertions;
using MyProject.Domain;
using Xunit;

namespace MyProject.Test
{
    public class MyCustomerHandlerTests
    {
        private MyCustomerHandler _underTest;

        public MyCustomerHandlerTests()
        {
            _underTest = new MyCustomerHandler();
        }

        [Fact]
        public void GivenCustomerInfo_CreateCustomer_ShouldReturnNewCustomer()
        {
            // Arrange
            var name = "Donald Duck";
            var street = "1313 Webfoot Walk";
            var city = "Duckburg";

            // Act
            var actual = _underTest.CreateCustomer(name, street, city);

            // Assert
            actual.Id.Should().Be(1);
            actual.Name.Should().Be(name);
            actual.Address.Street.Should().Be(street);
            actual.Address.City.Should().Be(city);
        }

        [Fact]
        public void GivenCustomerInfo_CreateCustomer_ShouldReturnNewCustomer_UsingEquivalentTo()
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
            };
            actual.Should().BeEquivalentTo(expected);
        }
    }
}