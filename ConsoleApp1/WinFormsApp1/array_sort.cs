using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class array_sort : Form
    {
        public array_sort()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr1 = { 15,32,18,5,19,2,13,8,22};
            int[] arr2 = { 11, 12, 13, 14, 15, 16 };

            int c;
            int[] arr4;
            int[] arr5 = new int[arr1.Length];

            textBox1.AppendText("--- sort --- \r\n");
            Array.Sort(arr1);
            // sort array from index 1 to 3
            // Array.Sort(a,1,3);
            foreach (var item in arr1)
            {
                textBox1.AppendText(item.ToString() + "\r\n");
            }

            // search value 13 whether in array if exists return index otherwise returning value < 0;
            textBox1.AppendText("-- binary search --" + "\r\n");
            c = Array.BinarySearch(arr1, 18);
            if (c < 0)
            {
                textBox1.AppendText($"can't not find {c}");
            }
            else
            {
                textBox1.AppendText($"value 18 is located at position " + c.ToString() + " in array \r\n");
            }

            // clear
            textBox1.AppendText("--- clear --- \r\n");
            Array.Clear(arr1, 2, 4);
            foreach (var item in arr1)
            {
                textBox1.AppendText(item.ToString() + "\r\n");
            }

            // clone
            textBox1.AppendText("--- clone --- \r\n");
            arr4 = (int[])arr2.Clone();
            arr4[0] = 100;
            foreach (var item in arr4) {
                textBox1.AppendText(item.ToString() + "\r\n");
            }
            textBox1.AppendText("--- clone origin \r\n");
            foreach (var item in arr2) {
                textBox1.AppendText(item.ToString() + "\r\n");
            }
            

            // copy
            textBox1.AppendText("--- copy --- \r\n");
            Array.Copy(arr1, arr5, 5);
            foreach (ValueType item in arr5) {
                textBox1.AppendText(item.ToString() + "\r\n");
            }

            // copyTo
            textBox1.AppendText("--- copyto --- \r\n");
            arr1.CopyTo(arr5, 0);

            // Reverse
            textBox1.AppendText("--- Reverse --- \r\n");
            Array.Reverse(arr1);
            foreach (ValueType item in arr1) {
                textBox1.AppendText(item.ToString() + "\r\n");
            }
        }
    }
}
