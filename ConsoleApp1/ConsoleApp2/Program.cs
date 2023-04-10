
using ConsoleApp2.grind_169;
using ConsoleApp2.test_func;
using System.ComponentModel;
using ConsoleApp2.practice.abstract_p;
using ConsoleApp2.practice.Interface_p;
using ConsoleApp2.practice.Inheritence_p;
using ConsoleApp2.practice.Enumerate_p;
using ConsoleApp2.practice.poly.para;
using ConsoleApp2.practice.poly;
using ConsoleApp2.practice.linq_p;
using ConsoleApp2.practice.datetime_p;
using ConsoleApp2.practice.nullable_p;

namespace ConsoleApp2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //datetime_start.Start();
            //nullable_start.Start();
            explain_Main_start(args);
        }

        static void explain_Main_start(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Please input args");
                return;
            }

            bool isNum1Parsed = float.TryParse(args[0], out float num1);
            bool isNum2Parsed = float.TryParse(args[1], out float num2);

            if(!isNum1Parsed || !isNum2Parsed)
            {
                Console.WriteLine("Invalid arguments, please use the help command for instructions");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Hello " + args[0]);
            Console.WriteLine(args[1]);
            Console.ReadKey();
        }
    }
}