using System;
using System.Buffers;
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
    public partial class bubble_sort : Form
    {
        public bubble_sort()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = { 27, 22, 29, 15, 18 };
            int temp;
            string str = "";

            // move smaller value to the lower index position.
            for (int i = 0; i < array.Length; i++) { 
                for (int j = array.Length-1; j > i; j--) {
                        if (array[j - 1] > array[j]) {
                            temp = array[j-1];
                            array[j - 1] = array[j];
                            array[j] = temp;
                        }
                    }
            }

            foreach (int i in array) {
                str += i.ToString() + ", ";
            }
            textBox1.AppendText("排序後資料:" + str);
            
        }
    }
}
