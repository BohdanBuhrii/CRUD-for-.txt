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
        public string ConnectionString { get; }

        public TextConnection(string connectionString)//todo
        {
            ConnectionString = connectionString;
        }

        public TextDataReader GetDataReader(string TableName)
        {
            return new TextDataReader(this, TableName);
        }

        public Table GetTable(string tableName)//todo
        {
            return new Table(this,tableName);
        }
        
        public void CreateTable(string tableName, string[] columns)//todo
        {
            //need checking if table exist
            using (StreamWriter streamWriter= new StreamWriter(ConnectionString, true))
            {
                streamWriter.WriteLine(string.Format("<{0}>", tableName));
                streamWriter.WriteLine(string.Join("|", columns));
                streamWriter.WriteLine("<end>");
            }
        }

        public void UpdateTable(string tableName, string[] newColumns)
        { }
        //public void Read<T>()
        //{

        //}
        //public void Update() { }
        public void DeleteTable()
        { }
    }
}
