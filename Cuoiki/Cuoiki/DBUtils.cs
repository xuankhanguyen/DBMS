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
       
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"10.211.55.2";
            string database = "QLNS";
            string username = "sa";
            string password = "Docker123";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            //string connString = @"Data Source=LAPTOP-SH0M4EMV\SQLEXPRESS;Initial Catalog=QLNS;Integrated Security=True";
            return new SqlConnection(connString);
        }
    }
}
