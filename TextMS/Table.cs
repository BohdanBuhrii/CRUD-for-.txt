using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    public class Table
    {
        private TextConnection Connection;
        public string TableName { get; }
        public string[] Columns { get; }
        public List<string[]> Rows { get; }
        public bool Changed { get; }

        public Table(TextConnection connection, string tableName)
        {
            TableName = tableName;
            Connection = connection;
            TextDataReader reader = new TextDataReader(connection, tableName);
            Columns = reader.Columns;
            string[] row = new string[Columns.Length];
            int i = 0;
            Rows = new List<string[]>();

            while (reader.Read())
            {
                foreach (string column in Columns)
                {
                    row[i] = reader[column];
                    i++;
                }

                Rows.Add(row);
                i = 0;
            }
        }

        public string GetContent()
        {
            string result = "";
            foreach (string[] row in Rows)
            {
                result += string.Join("|", row) + "\n";
            }
            return result;
        }

        public override string ToString()
        {
            string result="";
            result += string.Format("<{0}>\n",TableName);
            result += string.Join("|", Columns) + "\n";
            result += GetContent();
            result += "<end>";
            return result;
        }

        public void ExecuteChanges()//todo
        {
            if (this.Changed)
            {

            }
        }
    }
}
