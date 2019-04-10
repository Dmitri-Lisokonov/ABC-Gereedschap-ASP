using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ABCGereedschap
{
    class Database
    {
        private static readonly string connectionString = @"Data Source=mssql.fhict.local;Initial Catalog=dbi390337;Persist Security Info=True;User ID=dbi390337;Password=willemII";


        public static SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }

        public static void CloseConnection(SqlConnection conn)
        {
            conn.Close();
        }
    }
}
