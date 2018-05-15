using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqiTransferData
{
    class DbHelper
    {


        MySqlConnection conn;


        public DbHelper()
        {
            string connectionName = ConfigurationManager.ConnectionStrings["localConnection"].ConnectionString;
            conn = new MySqlConnection(connectionName);
        }
        public MySqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public MySqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}
