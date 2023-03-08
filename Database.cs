using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Railway_System
{
    class Database
    {
        static string connection;
        public SqlConnection conn;
        public Database()
        {
            connection = "Server=.;Database=MersulTrenurilor;Trusted_Connection=true;";
            conn = new SqlConnection(connection);
        }
      
        public void Connect()
        {
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }
    }
}
