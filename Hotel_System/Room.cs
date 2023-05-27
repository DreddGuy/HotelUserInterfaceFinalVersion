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
    class Room
    {
        DBConnection conn = new DBConnection();
        //get all roomTypes
        public DataTable RoomTypeList()
        {
            string connectionString = "Data Source=DESKTOP-VUG11T1\\SQLEXPRESS; Initial Catalog=HotelData; Integrated Security=SSPI;";
            string query2 = "SELECT * FROM Rooms";

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

        //get all rooms based on type
        public DataTable RoomByType(int type)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rooms WHERE RoomType=@type and Locked = 'No'", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@type", SqlDbType.Int).Value = type;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //get room type id
        public int GetRoomType(int number)
        {
            SqlCommand command = new SqlCommand("SELECT RoomType FROM Rooms WHERE RoomNumber=@number", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@number", SqlDbType.Int).Value = number;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return Convert.ToInt32(table.Rows[0][0].ToString());
        }

        //set free to NO/YES
        public bool SetRoomFree(int number, String isNotLocked)
        {
            SqlCommand command = new SqlCommand("UPDATE `Rooms` SET `Locked`=@isNotLocked' WHERE `RoomNumber`=@number", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            command.Parameters.Add("@number", SqlDbType.Int).Value = number;
            command.Parameters.Add("@isNotLocked", SqlDbType.VarChar).Value = isNotLocked;

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

        //insert new room
        public bool InsertRoom(int number, int type, String phone, String NotLocked)
        {
            SqlCommand command = new SqlCommand();
            String queryInsert = "INSERT INTO `Rooms`(`RoomNumber`, `RoomType`, `Phone`, `Locked`) VALUES (@number, @type, @phone, @NotLocked)";
            command.CommandText = queryInsert;
            command.Connection = conn.GetConnection();
    
            command.Parameters.Add("@number", SqlDbType.Int).Value = number;
            command.Parameters.Add("@type", SqlDbType.Int).Value = type;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@NotLocked", SqlDbType.VarChar).Value = NotLocked;

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

        //get all rooms
        public DataTable GetAllRooms()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Rooms", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }


        //edit ROOM data
        public bool EditRoom(int number, int type, String phone, String free)
        {
            SqlCommand command = new SqlCommand();
            String queryUpdate = "UPDATE Rooms SET RoomType=@type, Phone=@phone, Locked=@free WHERE RoomNumber=@number";
            command.CommandText = queryUpdate;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@number", SqlDbType.Int).Value = number;
            command.Parameters.Add("@type", SqlDbType.Int).Value = type;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@free", SqlDbType.VarChar).Value = free;

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

        //remove room
        public bool RemoveRoom(int number)
        {
            SqlCommand command = new SqlCommand();
            String queryDelete = "DELETE FROM Rooms WHERE RoomNumber=@number";
            command.CommandText = queryDelete;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@number", SqlDbType.Int).Value = number;

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
