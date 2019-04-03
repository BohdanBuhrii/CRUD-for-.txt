using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    public class TextDataReader
    {
        private readonly char separator = '|';
        private StreamReader streamReader;


        public string[] Columns { get; }

        private string[] currentLine;



        public TextDataReader(string connectionString, string tableName)
        {
            streamReader = new StreamReader(connectionString);

            string line="";
            while (line != string.Format("<{0}>", tableName))
            {
                line=streamReader.ReadLine();
            }
            if (streamReader.EndOfStream) throw new Exception(string.Format("Table \"{0}\" not found",
                tableName));
            else
            {
                Columns = streamReader.ReadLine().Split(separator);
            }
        }

        public bool Read()
        {
            currentLine = streamReader.ReadLine().Split(separator);
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


    }

}
