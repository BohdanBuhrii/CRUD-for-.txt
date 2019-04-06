using System;
using System.IO;

namespace TextMS
{
    public class TextDataReader : IDisposable
    {
        private TextConnection Connection;
        private StreamReader streamReader;
        
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

        //move current line to the next line
        public bool Read()
        {
            currentLine = streamReader.ReadLine().Split(Connection.separator[0]);
            if (currentLine[0] == "<end>") return false;
            else return true;
        }

        //Used to access the columns from the currentLine
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

        //IDisposable interface realization: 

        private bool disposed = false;

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
