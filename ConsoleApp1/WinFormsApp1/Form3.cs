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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int noddlePrice = 25;
            int sodaPrice = 30;
            int noddleNum = Convert.ToInt32(textBox1.Text);
            int sodaNum = Convert.ToInt32(textBox2.Text);

            int noodle_total = noddleNum * noddlePrice;
            int soda_total = sodaNum * sodaPrice;

            label3.Text = "總金額: " + Convert.ToString(noodle_total + soda_total);
        }


    }
}
