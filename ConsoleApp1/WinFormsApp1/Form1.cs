using Microsoft.VisualBasic;
using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float cTemp, fTemp;
            cTemp = Convert.ToSingle(textBox1.Text);
            fTemp = cTemp * 9 / 5 + 32;
            fTemp = cTemp * 1.8f + 32;
            label3.Text = Convert.ToString(fTemp);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string caption, text;
            DialogResult result;
            text = textBox2.Text;
            caption = textBox3.Text;

            result = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            label3.Text = result.ToString();
        }
    }
}