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
            string datasource = @"10.211.55.2";
            string database = "QLNS";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            //string connString = @"Data Source=DESKTOP-0VDMSUU\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            return new SqlConnection(connString);
        }
    }
}
