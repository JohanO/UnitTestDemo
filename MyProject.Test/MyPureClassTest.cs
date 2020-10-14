using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace MyProject.Test
{
    public class MyPureClassTest
    {
        private MyPureClass _underTest;

        public MyPureClassTest()
        {
            _underTest = new MyPureClass();
        }

        [Fact]
        public void Given3_PureFunction_ShouldReturn9()
        {
            // Arrange
            var input = 3;

            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            var expected = 9;
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(3, 9)]
        [InlineData(4, 16)]
        [InlineData(5, 25)]
        public void GivenInput_PureFunction_ShouldReturnExpected(int input, int expected)
        {
            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> TestCases =>
            new List<object[]>
            {
                new object[] { 6, 36 },
                new object[] { 7, 49 },
                new object[] { 8, 64 }
            };

        [Theory]
        [MemberData(nameof(TestCases))]
        public void GivenInput_PureFunction_ShouldReturnExpected_WhenUsingMemberData(int input, int expected)
        {
            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            actual.Should().Be(expected);
        }          
    }
}
