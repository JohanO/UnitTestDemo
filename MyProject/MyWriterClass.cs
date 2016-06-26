using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class MyWriterClass
    {
        private readonly IDataStore _dataStore;

        public MyWriterClass(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public void WriteData(int input) => _dataStore.SaveData(input + 5);
    }
}
