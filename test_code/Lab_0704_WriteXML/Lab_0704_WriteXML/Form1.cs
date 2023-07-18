using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Lab_0704_WriteXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriter w = XmlWriter.Create(@"c:\\temp\\booklist.xml");

            // write booklist element
            w.WriteStartElement("booklist");
            w.WriteAttributeString("count", "5");

            // write book element
            for (int i = 0; i < 9; i++)
            {
                w.WriteStartElement("book");
                w.WriteAttributeString("id", i.ToString());
                w.WriteElementString("title", "book" + i.ToString());
                w.WriteStartElement("price");
                    w.WriteAttributeString("unit-v2", (500 + i).ToString());
                    w.WriteString((500 + i).ToString());
                w.WriteEndElement();
                //w.WriteAttributeString("unit", "NTD");
                w.WriteEndElement();
            }

            w.WriteEndElement();
            w.Close();
            button1.Text = "ok";
        }
    }
}
