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
    class Reservation
    {
        DBConnection conn = new DBConnection();
        //get all reservations
        public DataTable GetAllReservations()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Reservations", conn.GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //make new reservation
        public bool MakeReservation(int room, string roomtype ,int CId, DateTime dateIn, DateTime dateOut)
        {
            SqlCommand command = new SqlCommand();
            String queryInsert = "INSERT INTO Reservations (Arrival,Checkout,RoomNo,RoomType,CustomerID) VALUES (@dateIn, @dateOut, @room, @roomtype, @CId)";
            command.CommandText = queryInsert;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@room", SqlDbType.Int ).Value = room;
            command.Parameters.Add("@roomtype", SqlDbType.VarChar).Value = roomtype;
            command.Parameters.Add("@dateIn", SqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dateOut", SqlDbType.Date).Value = dateOut;
            command.Parameters.Add("@CId", SqlDbType.Int).Value = CId;

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

        //edit reservation
        public bool EditReservation(int id , int room, string roomtype, int CId,DateTime dateIn, DateTime dateOut)
        {
            SqlCommand command = new SqlCommand();
            String queryUpdate = "UPDATE Reservations SET Arrival=@dateIn, CheckOut=@dateOut, RoomNo=@room, RoomType=@roomtype , CustomerID=@CId Where ReservID=@id";
            command.CommandText = queryUpdate;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@id", SqlDbType.Int ).Value = id;
            command.Parameters.Add("@room", SqlDbType.Int).Value = room;
            command.Parameters.Add("@roomtype", SqlDbType.VarChar).Value = roomtype;
            command.Parameters.Add("@dateIn", SqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dateOut", SqlDbType.Date).Value = dateOut;
            command.Parameters.Add("@CId", SqlDbType.Int).Value = CId;

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
        public bool RemoveReservation(int id)
        {
            SqlCommand command = new SqlCommand();
            String queryDelete = "DELETE FROM Reservations WHERE ReservID=@id";
            command.CommandText = queryDelete;
            command.Connection = conn.GetConnection();

            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
