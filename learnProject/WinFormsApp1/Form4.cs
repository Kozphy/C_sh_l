using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        int count = 0;

        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            label6.Text = e.KeyCode.ToString();
            label11.Text = e.KeyValue.ToString();
            label13.Text = e.KeyData.ToString();

            label14.Text = Convert.ToString(++count);
        }

        private void Form4_KeyPress(object sender, KeyPressEventArgs e)
        {
            label8.Text = Convert.ToString(e.KeyChar);
        }

        private void Form4_KeyUp(object sender, KeyEventArgs e)
        {
            label14.Text = Convert.ToString(e.KeyData);
            count = 0;
        }

    }
}
