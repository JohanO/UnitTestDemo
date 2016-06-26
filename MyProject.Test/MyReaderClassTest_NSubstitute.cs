using NSubstitute;
using NUnit.Framework;

namespace MyProject.Test
{
    [TestFixture]
    public class MyReaderClassTest_NSubstitute
    {
        private MyReaderClass _underTest;
        private IDataSource _dataSource;

        [SetUp]
        public void SetUp()
        {
            _dataSource = Substitute.For<IDataSource>();
            _underTest = new MyReaderClass(_dataSource);
        }

        [Test]
        public void ReadData_WithDataSource5andInput3_ShouldReturn8()
        {
            // Arrange
            _dataSource.GetData().Returns(5);
            var input = 3;

            // Act
            var actual = _underTest.ReadData(input);

            // Assert
            var expected = 8;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
