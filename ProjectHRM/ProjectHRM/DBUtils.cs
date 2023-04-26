using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHRM
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"10.211.55.2";
            string database = "QLNS1";
            string username = "sa";
            string password = "Docker123";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            return new SqlConnection(connString) ;
        }
    }
}
