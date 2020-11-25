using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_DB.Model
{
    class SQLConnection
    {
        SqlConnection con;

        public SQLConnection()
        {
        }

        public SQLConnection(string connectionString)
        {
            con = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                return true;
            }
        }

        public SqlConnection getConnection()
        {
            return con;
        }

        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }
    }
}
