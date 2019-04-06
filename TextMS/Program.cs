using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextMS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*connection.DeleteTable("table2");
            //string tableName1 = "table1";
            //string[] columns1 = new string[] {"column1", "column2", "column3" };
            //connection.CreateTable(tableName,columns);

            //string tableName2 = "table2";
            //string[] columns2 = new string[] { "column1", "column2", "column3" };
            //connection.CreateTable(tableName2, columns2);

            //string tableName3 = "table3";
            string[] columns3 = new string[] { "column1", "column2", "column3", "column4" };
            //connection.CreateTable(tableName3, columns3);

            Table table1 = connection.GetTable("table1");
            //Table table2 = connection.GetTable("table2");
            //Table table3 = connection.GetTable("table3");

            ////Console.WriteLine(table1.GetContent());
            //Console.WriteLine(table1);
            //Console.WriteLine();
            //Console.WriteLine(table2);
            //Console.WriteLine();
            //Console.WriteLine(table3);
            //Console.WriteLine();
            */

            //////////////////////////////////////////////////////////////////////////////////

            //simple example//

            TextConnection connection = new TextConnection(
                @"D:\USERS\Buhrii_B\C#\Програмне забезпечення\TextMS\TextMS\TextBase.txt");//path to file


            string[] newcolumns = new string[] { "newcolumn1", "newcolumn2", "newcolumn3" };
            connection.CreateTable("newtable", newcolumns);

            Table table = connection.GetTable("newtable");
            table.Create("inew1", "inew2", "inew3");
            table.Create("inew4", "inew5", "inew6");
            table.Create("inew7", "inew8", "inew9");

            table.Delete("newcolumn2", "inew5"); 
            Console.WriteLine(string.Join(" ",table.Read("newcolumn1", "inew7")[0]));

            table.ExecuteChanges();//used to save changes to textbase

            Console.WriteLine("done");
            Console.Read();
        }
    }
}
