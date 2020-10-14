using FakeItEasy;
using FluentAssertions;
using MyProject.Data;
using Xunit;

namespace MyProject.Test
{
    public class MyReaderClassTest_FakeItEasy
    {
        private MyReaderClass _underTest;
        private IDataSource _dataSource;

        public MyReaderClassTest_FakeItEasy()
        {
            _dataSource = A.Fake<IDataSource>();
            _underTest = new MyReaderClass(_dataSource);
        }

        [Fact]
        public void GivenDataSource5AndInput3_ReadData_ShouldReturn8()
        {
            // Arrange
            A.CallTo(() => _dataSource.GetData()).Returns(5);
            var input = 3;

            // Act
            var actual = _underTest.ReadData(input);

            // Assert
            var expected = 8;
            actual.Should().Be(expected);
        }
    }
}
