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
    public partial class DateTimes : Form
    {
        public DateTimes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(2012, 1, 1);
            DateTime dt1 = new DateTime(2012, 1, 1, 14, 23, 45);
            TimeZoneInfo tz = TimeZoneInfo.Local;

            textBox1.Clear();
            textBox1.AppendText(dt.Date.ToString() + "\r\n");
            textBox1.AppendText(dt1.TimeOfDay.ToString() + "\r\n");
            textBox1.AppendText(tz.StandardName.ToString() + "\r\n");
            textBox1.AppendText(DateTime.Now.ToString() + "\r\n");
            textBox1.AppendText(dt1.Year.ToString() + "\r\n");

            DateTime dt3 = new DateTime(2000, 11, 25);
            DateTime dt4, dt5;
            int v;
            string str;

            dt4 = dt3.AddDays(10);
            textBox1.AppendText(dt4.ToString() + "\r\n");

            // compare datetime
            v = dt.CompareTo(new DateTime(1999, 1, 1));
            textBox1.AppendText(v.ToString() + "\r\n");
            
            // string to datetime
            dt5 = DateTime.Parse("2018/7/25T14:30");
            textBox1.AppendText(dt5.ToString() + "\r\n");

            textBox1.AppendText(dt3.Subtract(dt).ToString() + "\r\n");

            // show short time
            str = dt5.ToShortTimeString();
            textBox1.AppendText(str + "\r\n");


        }
    }
}
