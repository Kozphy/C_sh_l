using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.interface_test
{
    public partial class form_int1 : Form
    {
        public form_int1()
        {
            InitializeComponent();
        }
        interface Iface
        { 
            float price { get; set; }
            int number { get; set; }
            string name { get; }
            float GetAmont();
        }

        class Items : Iface
        { 
            public float price { get; set; }
            public int number { get; set; }
            public string name { get; }

            public Items(float p = 0, string str = "")
            {
                price = p;
                name = str;
                number = 0;
            }
            public float GetAmont()
            {
                return price * number;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float price;
            string name;

            price = float.Parse(textBox3.Text);
            name = textBox1.Text;

            Items usb = new Items(price, name);
            usb.number = int.Parse(textBox2.Text);
            label5.Text = usb.GetAmont().ToString();
            
        }
    }
}
