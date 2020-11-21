using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_DB.Model
{
    class SqlServerConnection
    {
        public static SqlConnection GetDBConnection(string connString)
        {
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
