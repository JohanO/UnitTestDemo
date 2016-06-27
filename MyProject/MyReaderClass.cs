using MyProject.Data;

namespace MyProject
{
    public class MyReaderClass
    {
        private readonly IDataSource _dataSource;

        public MyReaderClass(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public int ReadData(int input) => input + _dataSource.GetData();
    }
}
