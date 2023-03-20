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
    public partial class Mouse_event_form : Form
    {
        public Mouse_event_form()
        {
            InitializeComponent();
        }

        int count = 0;

        private void label1_MouseDown(object sender, EventArgs e)
        {
            label1.Text = "Mouse Down";
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.Text = "Mouse Enter";
        }
        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "Mouse Leave";
        }

        private void label1_MouseUp(object sender, EventArgs e)
        {
            label1.Text = "Mouse Up";
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Text = "Mouse Click";
        }

        private void label2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            label2.Text = "Mouse Double Click";
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = (++count).ToString();
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.Text = "Mouse Hover";
        }
    }
}
