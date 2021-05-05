using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            textBox1.Text = monthCalendar1.SelectionStart.ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
