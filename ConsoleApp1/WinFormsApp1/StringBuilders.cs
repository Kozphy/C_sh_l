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
    public partial class StringBuilders : Form
    {
        public StringBuilders()
        {
            InitializeComponent();
        }

        StringBuilder str1;
        private void button1_Click(object sender, EventArgs e)
        {
            str1 = new StringBuilder(5);
            str1.Append("1234");
            textBox1.AppendText("Capacity=" + str1.Capacity.ToString() + "\r\n");

            str1.Append("5678");
            textBox1.AppendText("str=" + str1.ToString() + "\r\n");
            textBox1.AppendText("Capacity=" + str1.Capacity.ToString() + "\r\n");
            textBox1.AppendText("Length=" + str1.Length.ToString() + "\r\n");

            str1.Length = 15;
            textBox1.AppendText("Capacity=" + str1.Capacity.ToString() + "\r\n");
            textBox1.AppendText("Length=" + str1.Length.ToString() + "\r\n");
            textBox1.AppendText("str1= " + str1.ToString() + "\r\n");


            str1.Clear();
            str1.Append("123");
            textBox1.AppendText("str1=" + str1.ToString() + "\r\n");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder str1;

            // default capacity is 16
            textBox1.Clear();
            str1 = new StringBuilder();
            textBox1.AppendText(str1.Capacity.ToString() + "\r\n");

            // change str1 capacity
            str1.Append("12345678901234567");
            str1.Length = 10;
            textBox1.AppendText(str1.Capacity.ToString() + "\r\n");
            textBox1.AppendText(str1.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder str1 = new StringBuilder("123");
            StringBuilder str2 = new StringBuilder();
            char[] c = { 'a', 'b', 'c', 'd', 'e' };
            char[] c1 = new char[4];

            textBox1.Clear();

            // Append
            textBox1.AppendText(str1.Length.ToString() + "\r\n");
            str1.AppendLine();
            textBox1.AppendText(str1.Length.ToString() + "\r\n");

            // because of appendline str1 will be splited to two line
            str1.Append('c', 5).AppendLine("11111");
            textBox1.AppendText(str1.ToString());

            // AppendFormat example
            str2.AppendFormat("I and {0} went together to buy {1} notebook.", "min", 3);
            textBox1.AppendText(str2 + "\r\n");

            // CopyTo example
            str2.CopyTo(1, c1, 0, 4);
            textBox1.AppendText(new string(c1) + "\r\n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder str1 = new StringBuilder("abcd");
            StringBuilder str2 = new StringBuilder("1234567");

            textBox1.Clear();

            // Equals
            textBox1.AppendText(str1.Equals("abcd").ToString() + "\r\n");

            // Inserts
            str2.Insert(3, "abc", 2);
            textBox1.AppendText(str2.AppendLine().ToString());

            // Remove
            str2.Remove(3, 6);
            textBox1.AppendText(str2.ToString());

            // Replace
            str2.Clear();
            str2.Append("123abc456abc789abc");
            str2.Replace("abc", "qqq", 3, 9);
            textBox1.AppendText(str2.ToString());
           
        }
    }
}
