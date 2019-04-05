using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    public class TextDataReader : IDisposable
    {
        private TextConnection Connection;
        private StreamReader streamReader;
        private bool disposed = false;

        public string[] Columns { get; }
        private string[] currentLine;


        public TextDataReader(TextConnection connection, string tableName)
        {
            this.Connection = connection;
            streamReader = new StreamReader(connection.ConnectionString);

            string line="";
            while (line != string.Format("<{0}>", tableName))
            {
                line=streamReader.ReadLine();
            }
            if (streamReader.EndOfStream) throw new Exception(string.Format("Table \"{0}\" not found",
                tableName));
            else
            {
                Columns = streamReader.ReadLine().Split(connection.separator[0]);
            }
        }

        public bool Read()
        {
            currentLine = streamReader.ReadLine().Split(Connection.separator[0]);
            if (currentLine[0] == "<end>") return false;
            else return true;
        }

        public string this[string column]
        {
            get
            {
                int i = 0;
                foreach (string Column in Columns)
                {
                    if (Column.Equals(column)) return currentLine[i];
                    i++;
                }
                throw new Exception(string.Format("Current object haven't column \"{0}\"",
                    column));
            }
        }

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    
                   streamReader.Dispose();
                }

                disposed = true;
            }
        }

        ~TextDataReader()
        {
            Dispose(false);
        }
    }

}
