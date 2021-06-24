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
    /// <summary>
    /// Login page for registered persons
    /// </summary>
    public partial class login_page : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BQ7U5BGD\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
        int count = 0;

        public static string SetValueForUser = null;
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
        /// <summary>
        /// Login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-BQ7U5BGD\SQLEXPRESS;Initial Catalog=BookDB;Integrated Security=True");
            int count = 0;
            con.Open();

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

                SetValueForUser = textBox1.Text;
                main_page currentUser = new main_page();
                currentUser.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_page currentUser = new main_page();
            currentUser.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
