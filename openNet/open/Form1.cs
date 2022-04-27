using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace open
{
    public partial class Form1 : Form
    {
        private Form3 f3;
        private Form4 f4;
        private GameBoard gb;

        public Form1()
        {
            InitializeComponent();
            f3 = new Form3(this);
            f4 = new Form4(this);
            gb = new GameBoard(this);
             
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            f4.Show();
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (MessageBox.Show("Are You Sure?!", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                e.Cancel = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            gb.Show();
            gb.Location = this.Location;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            f3.Show();
            f3.Location = this.Location;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
