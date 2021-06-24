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
using System.Diagnostics;

namespace SoftwareEngProject
{
    public partial class main_page : Form
    {

         

        public main_page()
        {
            InitializeComponent();
            timer1.Start();
            label5.Text = DateTime.Now.ToLongTimeString();
            label6.Text = DateTime.Now.ToLongDateString();
            label13.Text = "Please login";
            if(login_page.SetValueForUser != null)
            {
                label13.Text = "Hi," + login_page.SetValueForUser;
            }
            else
            {
                label13.Text = "Please login";
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible == false)
            {
                groupBox1.Show();
            }
            else
            {
                groupBox1.Hide();
                textBox1.Text = null;
            }
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.Date.ToString("MM/dd/yyyy");

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=LAPTOP-BQ7U5BGD\SQLEXPRESS;Initial Catalog=Flight;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var departure = comboBox1.Text;
            var arrival = comboBox2.Text;
            var dateDeparture = textBox1.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    this.Hide();
                    string query = @"select * from FlightShedule where Departure='" + departure + "' AND Arrival='"+arrival+"' AND DateOfDeparture='"+ dateDeparture + "'";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataSet dataSet = new DataSet();

                    adapter.Fill(dataSet);

                    if (dataSet.Tables[0].Rows.Count != 0)
                    {
                        SearchResult result = new SearchResult();
                        result.dataGridView1.ReadOnly = true;
                        result.dataGridView1.DataSource = dataSet.Tables[0];
                        result.Show();
                    }
                    else
                    {
                        MessageBox.Show("There is no flights for this day.");
                    }

                    connection.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Exception");
            }


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_page currentUser = new login_page();
            currentUser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            feedback_page currentUser = new feedback_page();
            currentUser.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
            label6.Text = DateTime.Now.ToLongDateString();
            timer1.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            my_booking currentUser = new my_booking();
            currentUser.Show();
        }

        private void main_page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form formBackground = new Form();
            try
            {
                using (studentoffer uu = new studentoffer())
                {
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                    formBackground.WindowState = FormWindowState.Maximized;
                    formBackground.TopMost = true;
                    formBackground.Location = this.Location;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    uu.Owner = formBackground;
                    uu.ShowDialog();

                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
