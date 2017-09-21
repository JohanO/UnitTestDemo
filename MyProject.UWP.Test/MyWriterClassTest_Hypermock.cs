namespace MyProject.UWP.Test
{
    using HyperMock;
    using MyProject.Data;
    using WEX.TestExecution.Markup;

    [TestClass]
    public class MyWriterClassTest_Hypermock
    {
        private MyWriterClass _underTest;
        private Mock<IDataStore> _dataStore;

        [TestInitialize]
        public void SetUp()
        {
            _dataStore = Mock.Create<IDataStore>();
            _underTest = new MyWriterClass(_dataStore.Object);
        }

        [TestMethod]
        public void WriteData_With3_ShouldSave8()
        {
            // Arrange
            var input = 3;

            // Act
            _underTest.WriteData(input);

            // Assert
            var expected = 8;
            _dataStore.Verify(x => x.SaveData(expected), Occurred.Once());
        }
    }
}
