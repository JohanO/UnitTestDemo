using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class MyReaderClass
    {
        private IDataSource _dataSource;

        public MyReaderClass(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public int ReadData(int input) => input + _dataSource.GetData();
    }
}
