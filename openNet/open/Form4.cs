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
    public partial class Form4 : Form
    {
        private Form1 f4;
        public Form4(Form1 f1)
        {
            InitializeComponent();
            f1=f4;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Hide();
            f4.Show();
        }
    }
}
