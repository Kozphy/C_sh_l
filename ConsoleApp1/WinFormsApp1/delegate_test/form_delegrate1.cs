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
    public partial class form_delegrate1 : Form
    {
        public form_delegrate1()
        {
            InitializeComponent();
        }

        delegate string Dgate(string str);
        public string HiMary(string str)
        {
            return "Hello, good morning." + str + "\r\n";
        }

        public string HiJohn(string str) 
        { 
            return "Hello, gooda afternoon." + str + "\r\n";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Dgate DelFunc;

            DelFunc = HiMary;
            textBox1.AppendText(DelFunc("Mary"));

            DelFunc = HiJohn;
            textBox1.AppendText(DelFunc("John"));
        }
    }
}
