﻿using System;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        int gender = 0;
        bool fgVel = false;
        bool fgHDC = false;
        int age = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = 1;
            groupBox2.Visible = true;
        }

        private void radioButton2_CheckedChanged(object                                                                                                                                                                                                                                        sender, EventArgs e)
        {
            gender = 0;
            groupBox2.Visible = false;
        }
        

    }
}
