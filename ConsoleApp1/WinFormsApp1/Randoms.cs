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
    public partial class Randoms : Form
    {
        Random rd;
        public Randoms()
        {
            InitializeComponent();

            rd = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < 10; i++)
            {
                textBox1.AppendText(rd.Next().ToString() + "\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < 10; i++)
            {
                textBox1.AppendText(rd.Next(10).ToString() + "\r\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < 10; i++)
            {
                textBox1.AppendText(rd.Next(10, 20).ToString() + "\r\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            for (int i = 0; i < 10; i++) {
                textBox1.AppendText(rd.NextDouble().ToString() + "\r\n");
            }
        }
    }
}
