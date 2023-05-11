using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Indexer
{
    public partial class Indexer1 : Form
    {

        MyClass myclass;
        Random rd = new Random();
        public Indexer1()
        {
            InitializeComponent();
            myclass = new MyClass(10);

            for (int i = 0; i < 10; i++)
            {
                myclass[i] = rd.Next(100);
            }
        }


        class MyClass
        {
            public int[] number;
            public MyClass(int num)
            {
                if (num <= 0)
                {
                    num = 10;
                }

                number = new int[num];
            }

            public int this[int i]
            {
                get => number[i];
                set => number[i] = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // through indexer
                textBox1.AppendText(myclass[i].ToString() + "\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                // through number
                textBox1.AppendText(myclass.number[i].ToString() + "\r\n");
            }
        }
    }
}
