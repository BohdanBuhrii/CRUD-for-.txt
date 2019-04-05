using System;
using System.Collections.Generic;
using System.IO;
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
        private bool Changed = false;

        public Table(TextConnection connection, string tableName)
        {
            TableName = tableName;
            Connection = connection;
            Rows = new List<string[]>();

            using (TextDataReader reader = new TextDataReader(connection, tableName))
            {
                Columns = reader.Columns;

                string[] row;
                int i = 0;
                
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
            Changed = true;

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
            Rows.Add(row);
        }

        public List<string[]> Read(string column, string condition)
        {
            List<string[]> result = new List<string[]>();
            if (!Columns.Contains(column)) throw new Exception("Column not found");

            int columnIndex = 0;
            while (Columns[columnIndex] != column) columnIndex++;

            foreach (string[] row in Rows)
            {
                if (row[columnIndex] == condition) result.Add(row);
            }

            return result;
        }

        public void Update(string column, string condition, params string[] newObject)
        {
            Changed = true;

            Delete(column, condition);
            Create(newObject);
        }

        public void Delete(string column, string condition)
        {
            Changed = true;

            if (!Columns.Contains(column)) throw new Exception("Column not found");
            int columnIndex = 0;
            while (Columns[columnIndex] != column) columnIndex++;

            for (int i=0;i<Rows.Count;)
            {
                if (Rows[i][columnIndex] == condition) Rows.Remove(Rows[i]);
                else i++;
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

        public void ExecuteChanges()
        {
            if (this.Changed)
            {
                Connection.DeleteTable(TableName);
                using (StreamWriter writer = new StreamWriter(Connection.ConnectionString, true))
                {
                    //writer. (this.ToString());
                    writer.WriteLine(string.Format("<{0}>\n", TableName));

                    writer.WriteLine(string.Join(Connection.separator, Columns));

                    foreach (string[] row in Rows)
                    {
                        writer.WriteLine(string.Join(Connection.separator, row));
                    }

                    writer.WriteLine("<end>");
                }
            }
        }
    }
}
