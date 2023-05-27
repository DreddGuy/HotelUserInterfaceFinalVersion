using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelUserInterfaceTest
{
    public partial class ManageRoomsForm : Form
    {
        public ManageRoomsForm()
        {
            InitializeComponent();
        }

        Room room = new Room();
        private void ManageRoomsForm_Load(object sender, EventArgs e)
        {
            //cbRoomType.DataSource = room.RoomTypeList();
            //cbRoomType.DisplayMember = "label";
            //cbRoomType.ValueMember = "id";

            dgvRooms.DataSource = room.GetAllRooms();

        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
