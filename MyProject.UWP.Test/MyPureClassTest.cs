//----------------------------------------------------------------------------------------------------------------------
// <copyright file="MyProject.UWP.Test" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>Defines the MyProject.UWP.Test type.</summary>
//----------------------------------------------------------------------------------------------------------------------
namespace MyProject.UWP.Test
{
    using System;
    using WEX.Logging.Interop;
    using WEX.TestExecution;
    using WEX.TestExecution.Markup;


    [TestClass]
    public class MyPureClassTest
    {
        private MyPureClass _underTest;

        [TestInitialize]
        public void SetUp()
        {
            _underTest = new MyPureClass();
        }

        [TestMethod]
        public void PureFunction_With3_ShouldReturn9()
        {
            // Arrange
            var input = 3;

            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            var expected = 9;
            Verify.AreEqual(expected, actual);
        }

        #region Light Weight Data-driven testing

        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestProperty("Data:Values", "{3:9, 4:16, 5:25}")]
        public void PureFunction_LightWeightDataDriven()
        {
            // Arrange
            var values = TestContext.DataRow["Values"].ToString().Split(':');
            var input = int.Parse(values[0]);

            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            var expected = int.Parse(values[1]);
            Verify.AreEqual(expected, actual);
        }

        #endregion

        #region XML Data-driven testing

        [TestMethod]
        [DataSource("Table:TestData.xml#PureFunctionData")]
        public void PureFunction_XmlDataDriven()
        {
            // Arrange
            var input = (int)TestContext.DataRow["Input"];

            // Act
            var actual = _underTest.PureFunction(input);

            // Assert
            var expected = (int)TestContext.DataRow["Expected"];
            Verify.AreEqual(expected, actual);
        }

        #endregion
    }
}
