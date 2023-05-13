using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        bool fg;

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 0;

            fg = true;

            while (fg == true)
            {
                label1.Text = num.ToString();
                num++;

                if (num == 10000)
                {
                    num = 0;
                }

                Application.DoEvents();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fg = false;
        }
    }
}
