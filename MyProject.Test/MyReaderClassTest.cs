using NUnit.Framework;

namespace MyProject.Test
{
    [TestFixture]
    public class MyReaderClassTest
    {
        private class DataSourceStub : IDataSource
        {
            public int ValueToReturn { get; set; }

            public int GetData() => ValueToReturn;
        }

        private MyReaderClass _underTest;
        private DataSourceStub _dataSource;

        [SetUp]
        public void SetUp()
        {
            _dataSource = new DataSourceStub();
            _underTest = new MyReaderClass(_dataSource);
        }

        [Test]
        public void ReadData_WithDataSource5andInput3_ShouldReturn8()
        {
            // Arrange
            _dataSource.ValueToReturn = 5;
            var input = 3;

            // Act
            var actual = _underTest.ReadData(input);

            // Assert
            var expected = 8;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}