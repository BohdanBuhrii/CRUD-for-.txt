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

        public TextDataReader GetDataReader()
        {
            return new TextDataReader();
        }

        public class TextDataReader
        {
            public StreamReader streamReader;

            TextDataReader(string connectionString)
            {
                streamReader = new StreamReader(connectionString);
            }

            public bool Read()
            {
                return true;
            }

            public string this[string column]
            {
                set { }
                get
                {
                    return "";
                }
            }


        }

        public void Create() { }
        public void Read<T>()
        {

        }
        public void Update() { }
        public void Delete() { }
    }
}
