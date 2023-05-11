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
    public partial class Strings : Form
    {
        public Strings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "abcdefghijk";
            string str2 = "accdefghijk";
            const string str3 = "how are you?";
            string str4 = "\0\0";
            string str5;
            int v;
            bool fg;
            string[] str6;

            textBox1.AppendText(str1.Length.ToString() + "\r\n");
            textBox1.AppendText(str3.Length.ToString() + "\r\n");
            textBox1.AppendText(str4.Length.ToString() + "\r\n");

            textBox1.AppendText(str1[3].ToString() + "\r\n");
            v = String.Compare(str1, str2);
            textBox1.AppendText(v.ToString() + "\r\n");

            // fill up
            str5 = str3.PadRight(20, 'c');
            textBox1.AppendText(str5 + "\r\n");

            // remove
            str5 = str1.Remove(2, 4);
            textBox1.AppendText(str5 + "\r\n");
            
            // replace s with 6
            str1 = "This is a book.";
            str5 = str1.Replace('s', '6');
            textBox1.AppendText(str5 + "\r\n");

            // split word
            str5 = "This is a book.";
            str6 = str5.Split(' ');
            foreach ( var s in str6)
                textBox1.AppendText(s + "\r\n");

            // trim
            str5 = " This is a book.   ".Trim();
            textBox1.AppendText(str5 + "\r\n");


            
        }
    }
}
