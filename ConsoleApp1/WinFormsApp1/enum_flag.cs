using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class enum_flag : Form
    {
        public enum_flag()
        {
            InitializeComponent();
        }

        enum status { none = 0, stereo = 1, repeat = 2, bass = 4 };
        status stus = status.none;

        private void button1_Click(object sender, EventArgs e)
        {
            status stus = status.none;
            if (checkBox1.Checked)
            {
                
                stus |= status.stereo;
            }
            if (checkBox2.Checked)
            {
                stus |= status.repeat;
            }
            if (checkBox3.Checked)
            {
                stus |= status.bass;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "";
            int st = (int)stus;

            if (st == (int)status.stereo)
            {
                str += "立體聲";
            }
            else if (st == (int)status.repeat)
            {
                str += "循環";
            }
            else if (st == (int)status.bass)
            {
                str += "重音";
            }

            if (str != "")
            {
                label1.Text = "狀態: " + str;
            }
            else {
                label1.Text = "沒有勾選";
            }
            
        }

    }
}
