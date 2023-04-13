using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2.practice.poly.read_write_file
{
    internal class Read
    {
        public void Read_file() 
        { 
            string text = File.ReadAllText(@"C:\Users\zixsa\source\repos\C_sh_l\ConsoleApp1\TextFile1.txt");
            Console.WriteLine($"TextFile contains following text: {text}");
        }
    }
}
