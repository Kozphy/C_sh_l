using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.delegate_test
{
    public partial class Multicast_delegate : Form
    {
        public Multicast_delegate()
        {
            InitializeComponent();
        }

        delegate void Dgate();

        public void PreWords()
        {
            textBox1.AppendText("today bargain price product. \r\n");
        }

        public void Item()
        {
            if (radioButton1.Checked)
            {
                textBox1.AppendText("double layer pancil case \r\n");
            }
            else 
            {
                textBox1.AppendText("fine handmade soap \r\n");
            }
        }

        public void Sold()
        { 
            Random rd = new Random();
            int num;

            num = rd.Next(1, 30);
            textBox1.AppendText("remain " + num + " \r\n");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dgate DelFunc1 = PreWords;
            Dgate DelFunc2 = Item;
            Dgate DelFunc3 = Sold;
            Dgate AllDel;

            AllDel = DelFunc1 + DelFunc2;
            AllDel();

            AllDel -= DelFunc2;
            AllDel += DelFunc3;
            AllDel();
        }
    }
}
