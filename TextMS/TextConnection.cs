using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    

    public class TextConnection //TODO
    {
        public readonly string separator = "|";

        public string ConnectionString { get; }


        public TextConnection(string connectionString, string separator = "|")
        {
            ConnectionString = connectionString;
        }

        public TextDataReader GetDataReader(string TableName)
        {
            return new TextDataReader(this, TableName);
        }

        public Table GetTable(string tableName)
        {
            return new Table(this,tableName);
        }
        
        public void CreateTable(string tableName, string[] columns)//todo
        {
            //need checking if table exist
            using (StreamWriter streamWriter= new StreamWriter(ConnectionString, true))
            {
                streamWriter.WriteLine(string.Format("<{0}>", tableName));
                streamWriter.WriteLine(string.Join(separator, columns));
                streamWriter.WriteLine("<end>");
            }
        }

        public void UpdateTable(string tableName, string[] newColumns)//todo(now do nothing)
        {

        }
        
        public void DeleteTable(string tableName)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(ConnectionString))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    if (line != string.Format("<{0}>", tableName))
                    {
                        lines.Add(line);
                    }
                    else
                    {
                        while (reader.ReadLine() != "<end>") ;
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter(ConnectionString))
            {
                foreach (string _line in lines)
                {
                    writer.WriteLine(_line);
                }
            }
        }
    }
}
