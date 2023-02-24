using Microsoft.VisualBasic;
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
    public partial class Form2 : Form
    {
        string account, password;

        private void Form2_Activated(object sender, EventArgs e)
        {
            label1.Text = "帳號: " + account;
            label2.Text = "密碼: " + password;
        }

        public Form2()
        {
            InitializeComponent();
            account = Interaction.InputBox("input account: ", "login", "Mary", -1, -1);
        }
    }
}
