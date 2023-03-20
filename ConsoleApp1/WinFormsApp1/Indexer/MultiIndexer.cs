using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Indexer
{
    public partial class MultiIndexer : Form
    {
        public MultiIndexer()
        {
            InitializeComponent();
        }

        class MyClass
        {
            int[] score;
            string[] name;

            public MyClass(int num)
            {
                if (num <= 0) {
                    num = 5;
                }
                score = new int[num];
                name = new string[num];
            }

            // add data: name score
            public void Add(int i, string str, int s) {
                if (i < 0 || i > score.Length - 1)
                    return;
                name[i] = str;
                score[i] = s;
            }

            public string this[int i]
            {
                // get element using indexer
                get {
                    if (i < 0 || i > name.Length - 1)
                        return "";
                    else
                        return name[i];
                }
            }
            // indexer: using name inquire score
            public int this[string str]
            {
                get
                {
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (str.Equals(name[i]))
                            return score[i];
                    }
                    return -1;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = 5;
            int index;
            string str;
            MyClass myclass = new MyClass(num);
            int[] score = new int[] {80,92,67,84,60 };
            string[] name = new string[] { "wang shax", "beauti girl", "wang low w", "mari", "yahan"};

            for (int i = 0; i < num; i++) {
                myclass.Add(i, name[i], score[i]);
            }

            index = Convert.ToInt32(textBox1.Text) - 1;

            if (index < 0 || index >= num)
            {
                MessageBox.Show("doesn't exist serial number.");
                return;
            }

            str = myclass[index];
            textBox2.AppendText(str + " score = ");
            textBox2.AppendText(myclass[str].ToString() + "\r\n");
        }
    }
}
