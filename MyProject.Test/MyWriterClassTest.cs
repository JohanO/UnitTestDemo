using FluentAssertions;
using MyProject.Data;
using Xunit;

namespace MyProject.Test
{
    public class MyWriterClassTest
    {
        private class DataStoreMock : IDataStore
        {
            public int SavedData { get; set; }

            public void SaveData(int data) => SavedData = data;
        }

        private MyWriterClass _underTest;
        private DataStoreMock _dataStore;

        public MyWriterClassTest()
        {
            _dataStore = new DataStoreMock();
            _underTest = new MyWriterClass(_dataStore);
        }

        [Fact]
        public void Given3_WriteData_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);

            // Assert
            var expected = 8;
            _dataStore.SavedData.Should().Be(expected);
        }
    }
}