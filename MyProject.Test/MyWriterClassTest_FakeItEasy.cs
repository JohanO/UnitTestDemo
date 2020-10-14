using FakeItEasy;
using MyProject.Data;
using Xunit;

namespace MyProject.Test
{
    public class MyWriterClassTest_FakeItEasy
    {
        private MyWriterClass _underTest;
        private IDataStore _dataStore;

        public MyWriterClassTest_FakeItEasy()
        {
            _dataStore = A.Fake<IDataStore>();
            _underTest = new MyWriterClass(_dataStore);
        }

        [Fact]
        public void WriteData_With3_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);

            // Assert
            var expected = 8;
            A.CallTo(() => _dataStore.SaveData(expected)).MustHaveHappened();
        }
    }
}