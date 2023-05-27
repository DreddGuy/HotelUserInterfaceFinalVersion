using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace HotelUserInterfaceTest
{

    /*
     * class for insert/update/delete/get all client
     * 
     * */
    class Client
    {
        DBConnection conn = new DBConnection();

        //insert new client
        public bool InsertClient(String fname, String lname, String phone, String country)
        {
            SqlCommand command = new SqlCommand();
            String queryInsert = "INSERT INTO Customers(FirstName,LastName,Phone,Country) VALUES (@fname, @lname, @phone, @country)";
            command.CommandText = queryInsert;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            conn.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.CloseConnection();
                return true;
            }
            else
            {
                conn.CloseConnection();
                return false;
            }
        }

        //get all clients
        public DataTable GetAllClients()
        {
            string connectionString = "Data Source=DREDD\\SQLEXPRESS;Initial Catalog=HotelData; Integrated Security=SSPI;";
            string query2 = "SELECT * FROM Customers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        
        }
        //edit client data
        public bool EditClient(int id, String fname, String lname, String phone, String country)
        {
            SqlCommand command = new SqlCommand();
            String queryUpdate = "UPDATE Customers SET FirstName=@fname, LastName=@lname, Phone=@phone, Country=@country WHERE CustomerID=@cid";
            command.CommandText = queryUpdate;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@cid", SqlDbType.Int).Value = id; 
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@country", SqlDbType.VarChar).Value = country;

            conn.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.CloseConnection();
                return true;
            }
            else
            {
                conn.CloseConnection();
                return false;
            }
        }

        //remove client
        public bool RemoveClient(int id)
        {
            SqlCommand command = new SqlCommand();
            String queryDelete = "DELETE FROM Customers WHERE CustomerID=@cid";
            command.CommandText = queryDelete;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@cid", SqlDbType.Int).Value = id; 

            conn.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.CloseConnection();
                return true;
            }
            else
            {
                conn.CloseConnection();
                return false;
            }
        }
    }
}
