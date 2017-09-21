namespace MyProject.UWP.Test
{
    using HyperMock;
    using MyProject.Data;
    using WEX.TestExecution;
    using WEX.TestExecution.Markup;

    [TestClass]
    public class MyReaderClassTest_Hypermock
    {
        private MyReaderClass _underTest;
        private Mock<IDataSource> _dataSource;

        [TestInitialize]
        public void SetUp()
        {
            _dataSource = Mock.Create<IDataSource>();
            _underTest = new MyReaderClass(_dataSource.Object);
        }

        [TestMethod]
        public void ReadData_WithDataSource5andInput3_ShouldReturn8()
        {
            // Arrange
            _dataSource.Setup(x => x.GetData()).Returns(5);
            var input = 3;

            // Act
            var actual = _underTest.ReadData(input);

            // Assert
            var expected = 8;
            Verify.AreEqual(expected, actual);
        }
    }
}
