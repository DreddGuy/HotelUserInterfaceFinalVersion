﻿using Hotel_System;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClientsForm manageCF = new ManageClientsForm();
            manageCF.ShowDialog();
        }

        private void manageRoomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageRoomsForm manageRF = new ManageRoomsForm();
            manageRF.ShowDialog();
        }

        private void manageReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageReservationsForm manageResF = new ManageReservationsForm();
            manageResF.ShowDialog();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void managePaymentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ManagePaymentsForm managePF = new ManagePaymentsForm();
            managePF.ShowDialog();
        }
    }
}
