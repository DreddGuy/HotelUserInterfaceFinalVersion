using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelUserInterfaceTest
{
    public partial class ManageReservationsForm : Form
    {
        public ManageReservationsForm()
        {
            InitializeComponent();
        }
        private void btnClearFields_Click(object sender, EventArgs e)
        {
            tbReservID.Text = "";
            tbClientID.SelectedIndex = 0;
            cbRoomType.SelectedIndex = 0;
            cbRoomNumber.SelectedIndex = 0; 
            dateTimePickerIN.Value = DateTime.Now;
            dateTimePickerOUT.Value = DateTime.Now;
        }

        Room room = new Room();
        Reservation reservation = new Reservation();
        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            string connectionString = ("Data Source=DREDD\\SQLEXPRESS; Initial Catalog=HotelData; Integrated Security=SSPI;");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CustomerID FROM Customers";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                tbClientID.DisplayMember = "CustomerID";
                tbClientID.ValueMember = "";
                tbClientID.DataSource = dataTable;

                string query2 = "SELECT RoomNumber FROM Rooms";

                SqlDataAdapter adapter2 = new SqlDataAdapter(query2, connection);
                DataTable dataTable2 = new DataTable();
                adapter2.Fill(dataTable2);

                cbRoomNumber.DisplayMember = "RoomNumber";
                cbRoomNumber.ValueMember = "";
                cbRoomNumber.DataSource = dataTable2;

                string query3 = "Select RoomType FROM RoomTypes";

                SqlDataAdapter adapter3 = new SqlDataAdapter(query3, connection);
                DataTable dataTable3 = new DataTable();
                adapter3.Fill(dataTable3);

                cbRoomType.DisplayMember = "RoomType";
                cbRoomType.ValueMember = "";
                cbRoomType.DataSource = dataTable3;
            }
            dgvReservations.DataSource = reservation.GetAllReservations();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            {

                int CId = Convert.ToInt32(tbClientID.Text);
                int room = Convert.ToInt32(cbRoomNumber.Text);
                string roomtype = (cbRoomType.Text.ToString());
                DateTime dateIn = dateTimePickerIN.Value;
                DateTime dateOut = dateTimePickerOUT.Value;

                if (dateIn < DateTime.Now)
                {
                    MessageBox.Show("The Date must be Greater Or Equal than Current Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateOut < dateIn)
                {
                    MessageBox.Show("The DateOut must be Greater Or Equal than DateIn", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else

                {
                    var abc = new Reservation();
                    abc.MakeReservation(room, roomtype ,CId, dateIn, dateOut);
                    MessageBox.Show("Reservation successfully made!", "Reservation Made", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReservations.DataSource = reservation.GetAllReservations();
                }

                
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            {
                int id = Convert.ToInt32(tbReservID.Text);
                int CId = Convert.ToInt32(tbClientID.Text);
                int room = Convert.ToInt32(cbRoomNumber.Text);
                string roomtype = (cbRoomType.Text.ToString());
                DateTime dateIn = dateTimePickerIN.Value;
                DateTime dateOut = dateTimePickerOUT.Value;

                if (dateIn < DateTime.Now)
                {
                    MessageBox.Show("The Date must be Greater Or Equal than Current Date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateOut < dateIn)
                {
                    MessageBox.Show("The DateOut must be Greater Or Equal than DateIn", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var abc = new Reservation();
                    abc.EditReservation(id,room, roomtype, CId, dateIn, dateOut);
                    MessageBox.Show("Reservation data updated!", "Edit Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReservations.DataSource = reservation.GetAllReservations();
                }


            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            
            {
                int reservationID = Convert.ToInt32(tbReservID.Text);

                if (reservation.RemoveReservation(reservationID))
                {  
                    dgvReservations.DataSource = reservation.GetAllReservations();
                    MessageBox.Show("Reservation deleted successfully!", "Reservation Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearFields.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERROR - Reservation not deleted!", "Reservation Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //display room's number depending on selected type
                int type = Convert.ToInt32(cbRoomType.SelectedValue.ToString());
                cbRoomNumber.DataSource = room.RoomByType(type);
                cbRoomNumber.DisplayMember = "RoomNumber";
                cbRoomNumber.ValueMember = "";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Room number error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbReservID.Text = dgvReservations.CurrentRow.Cells[0].Value.ToString();
            tbClientID.Text = dgvReservations.CurrentRow.Cells[4].Value.ToString();
            cbRoomType.Text = dgvReservations.CurrentRow.Cells[5].Value.ToString();
            cbRoomNumber.Text = dgvReservations.CurrentRow.Cells[3].Value.ToString();
            dateTimePickerIN.Text = dgvReservations.CurrentRow.Cells[1].Value.ToString();
            dateTimePickerOUT.Text = dgvReservations.CurrentRow.Cells[2].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePickerOUT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbClientID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
