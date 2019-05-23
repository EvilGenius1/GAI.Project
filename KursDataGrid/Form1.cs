using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Carbon")
            {
                Form2 s = new Form2();
                s.Show();
                this.Hide();
            }
            else
            {
                textBox2.Text = "";
                MessageBox.Show("Try another password");
            }

        }
    }
}
