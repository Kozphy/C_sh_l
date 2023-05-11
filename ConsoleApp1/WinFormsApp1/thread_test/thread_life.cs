using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1.thread_test
{
    public partial class thread_life : Form
    {

        CancellationToken cts = new CancellationToken();
        public thread_life()
        {
            InitializeComponent();
        }

        bool fgDone_a, fgDone_b;
        int guess_a, guess_b;
        Thread th_a = null;
        bool fgRun;
        int num_a = 78, num_b = 50;

        void count_a(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            { 
                Random rd = new Random();

                try
                {
                    while (guess_a != num_a)
                    {
                        guess_a = rd.Next(1, 101);
                        Thread.Sleep(100);
                    }
                    fgDone_a = true;
                }
                catch (ThreadAbortException ex)
                {
                    timer1.Enabled = false;
                }
                catch (ThreadInterruptedException ex)
                {
                    timer1.Enabled = false;
                }
            }
        }

        void count_b()
        {
            Random rd = new Random();

            while (guess_b != num_b && fgRun)
            {
                guess_b = rd.Next(1, 101);
                Thread.Sleep(100);
            }
            fgDone_b = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.AppendText(guess_a.ToString() + "\r\n");
            if (fgDone_a)
            {
                timer1.Enabled = false;
                textBox1.AppendText("Found it! \r\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread thd = new Thread(() => count_a(cts.Token));
            th_a = thd;
            fgDone_a = false;
            guess_a = -1;
            thd.Start();
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("using Abort() terminate thread \r\n");
            cts.Cancel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("Interrupt() terminate thread \r\n");
            th_a.Interrupt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread thd = new Thread(count_b);

            fgDone_b = false;
            guess_b = -1;
            fgRun = true;
            thd.Start();
            timer2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fgRun = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox2.AppendText(guess_b.ToString() + "\r\n");
            if (fgDone_b)
            {
                timer2.Enabled = false;
                if (!fgRun)
                    textBox2.AppendText("thread ending \r\n");
                else
                    textBox2.AppendText("Found it \r\n");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (th_a != null)
                th_a.Abort();

            fgRun = false;
        }

    }
}
