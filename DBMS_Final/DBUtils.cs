using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuoiki
{
    class DBUtils
    {
        public static string username = "";
        public static string password = "";
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"LAPTOP-SH0M4EMV\SQLEXPRESS";
            string database = "QLNS";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            //string connString = @"Data Source=DESKTOP-H2SC4QA\MSSQLSERVER02;Initial Catalog=QLNS;Integrated Security=True";
            return new SqlConnection(connString);
        }
    }
}
