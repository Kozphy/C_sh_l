using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0, j = 255; i <= 255; i++, j--)
            {
                textBox1.BackColor = Color.FromArgb(255, j, i);
                Refresh();
                System.Threading.Thread.Sleep(10);
            }
        }


    }
}
