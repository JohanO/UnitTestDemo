﻿using FluentAssertions;
using MyProject.Data;
using Xunit;

namespace MyProject.Test
{
    public class MyReaderClassTest
    {
        private class DataSourceStub : IDataSource
        {
            public int ValueToReturn { get; set; }

            public int GetData() => ValueToReturn;
        }

        private MyReaderClass _underTest;
        private DataSourceStub _dataSource;

        public MyReaderClassTest()
        {
            _dataSource = new DataSourceStub();
            _underTest = new MyReaderClass(_dataSource);
        }

        [Fact]
        public void GivenDataSource5AndInput3_ReadData_ShouldReturn8()
        {
            // Arrange
            _dataSource.ValueToReturn = 5;
            var input = 3;

            // Act
            var actual = _underTest.ReadData(input);

            // Assert
            var expected = 8;
            actual.Should().Be(expected);
        }
    }
}