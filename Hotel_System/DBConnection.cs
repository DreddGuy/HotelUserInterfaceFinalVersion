using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUserInterfaceTest
{
    /*
     * connection between app and MySQL database
     */
    class DBConnection
    {
        public SqlConnection _connection = new SqlConnection ("Data Source=DREDD\\SQLEXPRESS; Initial Catalog=HotelData; Integrated Security=SSPI;");

        //return connection
        public SqlConnection GetConnection()
        {
            return _connection;
        }

        //open connection
        public void OpenConnection()
        {
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        } 
        
        //close connection
        public void CloseConnection()
        {
            if(_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
