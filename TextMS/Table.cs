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

            using (TextDataReader reader = new TextDataReader(connection, tableName))
            {
                Columns = reader.Columns;

                string[] row;
                int i = 0;
                Rows = new List<string[]>();

                while (reader.Read())
                {
                    row = new string[Columns.Length];

                    foreach (string column in Columns)
                    {
                        row[i] = reader[column];
                        i++;
                    }

                    Rows.Add(row);
                    i = 0;
                }
            }
        }

        public string GetContent()
        {
            string result = "";
            foreach (string[] row in Rows)
            {
                result += string.Join(Connection.separator, row) + "\n";
            }
            return result;
        }


        public void Create(params string[] newObject)
        {
            int len = Columns.Length;
            string[] row = new string[len];
            int i = 0;
            
            foreach (string item in newObject)
            {
                row[i] = item;
                i++;
                if (i == len) break;
            }
            while (i<len)
            {
                row[i] = "null";
                i++;
            }
        }

        public List<string[]> Read(string column, string condition)//todo
        {
            List<string[]> result = new List<string[]>();
            if (!Columns.Contains(column)) throw new Exception("Column not found");

            int columnIndex = 0;
            while (Columns[columnIndex] != column) columnIndex++;

            foreach (string[] row in Rows)
            {
                if (row[columnIndex] == condition) Rows.Remove(row);
            }

            return result;
        }

        public void Update(string column, string condition, params string[] newObject)
        {
            Delete(column, condition);
            Create(newObject);
        }

        public void Delete(string column, string condition)
        {
            if (!Columns.Contains(column)) throw new Exception("Column not found");
            int columnIndex = 0;
            while (Columns[columnIndex] != column) columnIndex++;

            foreach (string[] row in Rows)
            {
                if (row[columnIndex] == condition) Rows.Remove(row);
            }
        }


        public override string ToString()
        {
            string result="";
            result += string.Format("<{0}>\n",TableName);
            result += string.Join(Connection.separator, Columns) + "\n";
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
