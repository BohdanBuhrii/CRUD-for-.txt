using System.Collections.Generic;
using System.IO;


namespace TextMS
{
    

    public class TextConnection //TODO
    {
        public readonly string separator = "|";

        public string ConnectionString { get; } //path to .txt file (textbase)


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
        
        //add new table to textbase
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

        //redesign an exist table
        public void UpdateTable(string tableName, string[] newColumns)//todo(now do nothing)
        {

        }
        
        //delete table
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
