using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.interface_test
{
    public partial class Form_explicit_or_without : Form
    {
        public Form_explicit_or_without()
        {
            InitializeComponent();
        }

        interface IfaceA
        {
            string ShowInfo();
        }

        interface IfaceB
        {
            string ShowInfo();
        }

        class MyClass1 : IfaceA, IfaceB
        {
            public string ShowInfo()
            {
                return "ShowInfo";
            }
        }

        class MyClass2 : IfaceA, IfaceB
        {
            string IfaceA.ShowInfo()
            {
                return "ShowInfo for IfaceA";
            }

            string IfaceB.ShowInfo()
            {
                return "ShowInfo for IfaceB";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyClass1 my1 = new MyClass1();
            IfaceA fa = my1;
            IfaceA fb = my1;

            textBox1.AppendText(fa.ShowInfo() + "\r\n");
            textBox1.AppendText(fb.ShowInfo() + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MyClass2 my2 = new MyClass2();
            IfaceA fa = my2;
            IfaceA fb = my2;

            textBox1.AppendText(fa.ShowInfo() + "\r\n");
            textBox1.AppendText(fb.ShowInfo() + "\r\n");

        }
    }
}
