namespace MyProject.UWP.Test
{
    using ExpectedObjects;
    using MyProject.Domain;
    using WEX.TestExecution;
    using WEX.TestExecution.Markup;

    [TestClass]
    public class MyCustomerHandlerTest
    {
        private MyCustomerHandler _underTest;

        [TestInitialize]
        public void SetUp()
        {
            _underTest = new MyCustomerHandler();
        }

        [TestMethod]
        public void CreateCustomer_ShouldReturnNewCustomer()
        {
            // Arrange
            var name = "Donald Duck";
            var street = "1313 Webfoot Walk";
            var city = "Duckburg";

            // Act
            var actual = _underTest.CreateCustomer(name, street, city);

            // Assert
            Verify.AreEqual(1, actual.Id);
            Verify.AreEqual(name, actual.Name);
            Verify.AreEqual(street, actual.Address.Street);
            Verify.AreEqual(city, actual.Address.City);
        }

        [TestMethod]
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
