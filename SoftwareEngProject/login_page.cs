using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SoftwareEngProject
{
    public partial class login_page : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=software-project2021.database.windows.net;User ID=Margulan;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        int count = 0;

        public static string SetValueForUser = "";
        public login_page()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = con.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Users where UserName='" + textBox1.Text + "' and Passwordd='" + textBox2.Text + "'";
            command.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            count = Convert.ToInt32(dataTable.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("ID or Password doesn't match.\nIf you do not have an account then register below!");

            }
            else
            {
                this.Hide();

                SetValueForUser = textBox2.Text;
                after_login currentUser = new after_login();
                currentUser.Show();
            }

        }
    }
}
