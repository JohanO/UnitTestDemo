namespace MyProject.UWP.Test
{
    using MyProject.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WEX.TestExecution;
    using WEX.TestExecution.Markup;

    [TestClass]
    public class MyWriterClassTest
    {
        private class DataStoreMock : IDataStore
        {
            public int SavedData { get; set; }

            public void SaveData(int data) => SavedData = data;
        }

        private MyWriterClass _underTest;
        private DataStoreMock _dataStore;

        [TestInitialize]
        public void SetUp()
        {
            _dataStore = new DataStoreMock();
            _underTest = new MyWriterClass(_dataStore);
        }

        [TestMethod]
        public void WriteData_With3_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);
            var actual = _dataStore.SavedData;

            // Assert
            var expected = 8;
            Verify.AreEqual(expected, actual);
        }
    }
}
