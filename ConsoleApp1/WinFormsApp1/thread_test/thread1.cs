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
    public partial class thread1 : Form
    {
        public thread1()
        {
            InitializeComponent();
        }
        bool fgDone;
        Int32 sum;
        int guess;

        void count()
        {
            while (sum < int.MaxValue)
                sum++;
            fgDone = true;
        }

        void count_param(object num)
        {
            Random rd = new Random();

            while (guess != (int)num)
            {
                guess = rd.Next(1, 101);
                Thread.Sleep(100);
            };
            fgDone = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("start count \r\n");
            sum = 0;

            while (sum < int.MaxValue)
                sum++;
            textBox1.AppendText("count end, sum= " + sum.ToString() + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart thdStart = new ThreadStart(count);
            Thread thd = new Thread(thdStart);

            sum = 0;
            fgDone = false;
            textBox1.AppendText("Thread is starting \r\n");

            thd.Start();
            timer1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = 78;
            ParameterizedThreadStart paramStart = new ParameterizedThreadStart(count_param);
            Thread thd = new Thread(paramStart);

            fgDone = false;
            guess = -1;
            thd.Start(num);
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fgDone)
            {
                timer1.Enabled = false;
                textBox1.AppendText("count end, sum= " + sum.ToString() + "\r\n");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox1.AppendText(guess.ToString() + "\r\n");
            if (fgDone)
            {
                timer2.Enabled = false;
                textBox1.AppendText("have found \r\n");
            }
        }
    }
}
