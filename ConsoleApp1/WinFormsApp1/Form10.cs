using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        bool fg = false;


        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            int i = 1;

            textBox1.Clear();

            do
            {
                sum += i;
                textBox1.AppendText(sum.ToString() + "\r\n");
                i++;
                Application.DoEvents();
            } while (fg == true && i <= 10);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            fg = checkBox1.Checked;
            checkBox1.Text = "fg=" + fg.ToString();
        }
    }
}
