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
            TextConnection connection = new TextConnection(
                @"D:\USERS\Buhrii_B\C#\Програмне забезпечення\TextMS\TextMS\TextBase.txt");
            connection.DeleteTable("table2");
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
            

            Console.WriteLine("done");
            Console.Read();
        }
    }
}
