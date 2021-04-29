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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
