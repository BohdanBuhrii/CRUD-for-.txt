using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    class Program
    {
        static void CreateTables(TextConnection connection)
        {
            
            string tableName1 = "University";
            string[] newcolumns1 = new string[] { "name", "rating", "city" };
            connection.CreateTable(tableName1, newcolumns1);

            Table table1 = connection.GetTable(tableName1);
            table1.Create("Lviv National University of Ivan Franko", "100", "Lviv");
            table1.Create("Ukrainian Catholic University", "90", "Lviv");
            table1.Create("National University of 'Kyiv-Mohyla Academy'", "95", "Kyiv");

            table1.ExecuteChanges();                //used to save changes to textbase

            string tableName2 = "Subject";
            string[] newcolumns2 = new string[] { "subj_name", "semester" };
            connection.CreateTable(tableName2, newcolumns2);

            Table table2 = connection.GetTable(tableName2);
            table2.Create("Mathematical analysis", "3");
            table2.Create("English", "4");
            table2.Create("Database SQL", "2");

            table2.ExecuteChanges();
        }

        static void Main(string[] args)
        {
            TextConnection connection = new TextConnection(
              @"\..\..\TextBase.txt");  //path to file


            CreateTables(connection);

            Menu menu = new Menu(connection);
        }
    }
}
