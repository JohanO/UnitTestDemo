using MyProject.Data;
using NSubstitute;
using NUnit.Framework;

namespace MyProject.Test
{
    [TestFixture]
    public class MyWriterClassTest_NSubstitute1
    {
        private MyWriterClass _underTest;
        private IDataStore _dataStore;

        [SetUp]
        public void SetUp()
        {
            _dataStore = Substitute.For<IDataStore>();
            _underTest = new MyWriterClass(_dataStore);
        }

        [Test]
        public void WriteData_With3_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);

            // Assert
            var expected = 8;
            _dataStore.Received().SaveData(expected);
        }
    }
}