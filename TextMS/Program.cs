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
            //string tableName = "table1";
            //string[] columns = new string[] {"column1", "column2", "column3" };
            //connection.CreateTable(tableName,columns);
            Table tabel1=connection.GetTable("table1");
            Console.WriteLine(tabel1);
            Console.WriteLine("done");
            Console.Read();
        }
    }
}
