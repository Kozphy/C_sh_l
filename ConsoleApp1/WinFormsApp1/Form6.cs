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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        int sum = 0;
        string str;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                str = "第 " + i.ToString() + " 次: " + sum.ToString() +
                    "+" + i.ToString() + "=" + (sum += i).ToString() + "\r\n";


                    textBox1.AppendText(str);
            }

            label2.Text = sum.ToString();
        }
    }
}
