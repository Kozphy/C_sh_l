using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.thread_test
{
    public partial class thread2 : Form
    {
        public thread2()
        {
            InitializeComponent();
        }

        Int32 sum;

        void count()
        {
            while (sum < int.MaxValue)
                sum++;
        }

        void count_param(object param)
        {
            Int32[] pp = (Int32[])param;

            while (pp[0] < int.MaxValue)
                pp[0]++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thd = new Thread(count);

            sum = 0;
            textBox1.AppendText("Thread is starting \r\n");

            thd.Start();
            textBox1.AppendText("using Join() method, " + "" + "Must wait thread executing end...\r\n");
            thd.Join();
            textBox1.AppendText("sum=" + sum.ToString() + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thd = new Thread(count_param);
            Int32[] sum1 = new Int32[] { 0 };

            textBox1.AppendText("Thread is starting \r\n");
            thd.Start(sum1);
            textBox1.AppendText("use Join() method, " + "" + "need to wait thread executing ending... \r\n");
            thd.Join();
            textBox1.AppendText("sum=" + sum1[0].ToString() + "\r\n");
        }
    }
}
