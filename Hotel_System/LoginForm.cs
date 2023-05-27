using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelUserInterfaceTest
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           // try
            {
                DBConnection conn = new DBConnection();
                DataTable table = new DataTable();        
                String query = "SELECT * FROM users WHERE username = @username AND password = @password";    
                string connectionString = "Data Source=DREDD\\SQLEXPRESS; Initial Catalog=HotelData; Integrated Security=SSPI;";
                string query2 = "SELECT * FROM users WHERE username = '"+ tbUsername.Text + "' AND password = "+ tbPassword.Text;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Access the data in each column by column name or index
                            string column1Value = row["username"].ToString();
                            string column2Value = row["password"].ToString();

                            // Do something with the data...
                            if (dataTable.Rows.Count > 0)
                            {
                                //show the main form
                                this.Hide();
                                MainForm mainForm = new MainForm();
                                mainForm.Show();
                            }
                            else
                            {
                                if (tbUsername.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Enter your username to Login", "Empty Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (tbPassword.Text.Trim().Equals(""))
                                {
                                    MessageBox.Show("Enter your Password to Login", "Empty Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("This username or password does not exists", "Wrong Username/Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    }
                }

                //if the username and the password exists
               
            //catch(Exception ex)
            {
             //  MessageBox.Show(ex.Message);
            }
           


           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
