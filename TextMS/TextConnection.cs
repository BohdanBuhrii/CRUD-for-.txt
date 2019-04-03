using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    class TextConnection //TODO
    {
        private readonly string ConnectionString;

        public TextConnection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public TextDataReader GetDataReader(string TableName)
        {
            return new TextDataReader(ConnectionString, TableName);
        }

        
        public void Create() { }
        public void Read<T>()
        {

        }
        public void Update() { }
        public void Delete() { }
    }
}
