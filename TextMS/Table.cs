using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TextMS
{
    public class Table
    {
        private TextConnection Connection;
        public string TableName { get; }
        public string[] Columns { get; }
        public List<string[]> Rows { get; }
        private bool Changed = false; //represent if table was changed

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

        //returns all rows from table in special format
        public string GetContent()
        {
            string result = "";
            foreach (string[] row in Rows)
            {
                result += string.Join(Connection.separator, row) + "\n";
            }
            return result;
        }

        //in SQL: INSERT INTO TableName VALUES (newObject)
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

        //in SQL: SELECT * FROM TableName WHERE column = condition
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

        //something like UPDATE in SQL
        public void Update(string column, string condition, params string[] newObject)
        {
            Changed = true;

            Delete(column, condition);
            Create(newObject);
        }

        //in SQL: DELETE FROM TableNane WHERE column = condition
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

        //IMPORTANT!!!
        //applies changes from table to textbase,
        //recomended to use it for each table at the end of program
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
            Changed = false;
        }
    }
}
