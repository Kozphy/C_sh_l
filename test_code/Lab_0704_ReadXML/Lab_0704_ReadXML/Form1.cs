using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace Lab_0704_ReadXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://news.ltn.com.tw/rss/all.xml", @"c:\temp\lab.xml");
 
            button1.Text = "OK";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\lab.xml");
            XmlNode title = doc.SelectSingleNode("/rss/channel/title");
            if (title != null)
            {
                listBox1.Items.Add(title.InnerText);
            }
            else {
                listBox1.Items.Add("Not Found");
            }
            //XmlNode title2 = doc.SelectSingleNode("/rss/channel/");
            //doc.SelectNodes();
            button2.Text = "OK";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // using System.Xml
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\lab.xml");
 
            XmlNodeList itemList = doc.SelectNodes("/rss/channel/item");
            foreach (XmlNode item in itemList)
            {
                Console.WriteLine(item.InnerText.GetType());
                string s = item.SelectSingleNode("./title").InnerText;
                listBox1.Items.Add(s);
            }
            button3.Text = "OK";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // using System.Xml
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\lab.xml");

            XmlNode objRss = doc.SelectSingleNode("/rss");
            listBox1.Items.Add(objRss.Attributes["version"].Value);
        }
    }
}
