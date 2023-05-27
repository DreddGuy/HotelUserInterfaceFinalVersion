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
    public partial class ManagePaymentsForm : Form
    {
        public ManagePaymentsForm()
        {
            InitializeComponent();
        }
        Payments room = new Payments();
        private void ManagePaymentsForm_Load_1(object sender, EventArgs e)
        {
            dgvPayments.DataSource = room.PaymentTypeList();
        }
    }
}
