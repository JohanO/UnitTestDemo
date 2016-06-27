using MyProject.Data;
using NUnit.Framework;

namespace MyProject.Test
{
    [TestFixture]
    public class MyWriterClassTest
    {
        private class DataStoreMock : IDataStore
        {
            public int SavedData { get; set; }

            public void SaveData(int data) => SavedData = data;
        }

        private MyWriterClass _underTest;
        private DataStoreMock _dataStore;

        [SetUp]
        public void SetUp()
        {
            _dataStore = new DataStoreMock();
            _underTest = new MyWriterClass(_dataStore);
        }

        [Test]
        public void WriteData_With3_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);
            var actual = _dataStore.SavedData;

            // Assert
            var expected = 8;
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}