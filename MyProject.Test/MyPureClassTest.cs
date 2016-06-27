using System.Collections.Generic;
using NUnit.Framework;

namespace MyProject.Test
{
    [TestFixture]
    public class MyPureClassTest
    {
        private MyPureClass _underTest;

        [SetUp]
        public void SetUp()
        {
            _underTest = new MyPureClass();
        }

        [Test]
        public void PureFunction_With3_ShouldReturn9()
        {
            // Arrange
            var input = 3;

            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            var expected = 9;
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(3, 9)]
        [TestCase(4, 16)]
        [TestCase(5, 25)]
        public void PureFunctionTest_Parameterized(int input, int expected)
        {
            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(8, ExpectedResult = 64)]
        public int PureFunctionTest_ParameterAndReturn(int input) => _underTest.PureFunction(input);


        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(6).Returns(36);
                yield return new TestCaseData(7).Returns(49);
                yield return new TestCaseData(8).Returns(64);
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public int PureFunctionTest_WithTestCaseSource(int input) => _underTest.PureFunction(input);
    }
}
