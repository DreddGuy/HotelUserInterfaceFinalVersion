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
    class Payments
    {
        DBConnection conn = new DBConnection();
        //get all Payments
        public DataTable PaymentTypeList()
        {
            string connectionString = "Data Source=DREDD\\SQLEXPRESS; Initial Catalog=HotelData; Integrated Security=SSPI;";
            string query2 = "SELECT * FROM Payments";

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
    }
}
