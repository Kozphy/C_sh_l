
using ConsoleApp2.grind_169;
using ConsoleApp2.test_func;
using System.ComponentModel;
using ConsoleApp2.practice.abstract_p;
using ConsoleApp2.practice.Interface_p;
using ConsoleApp2.practice.Inheritence_p;
using ConsoleApp2.practice.Enumerate_p;
using ConsoleApp2.practice.linq_p;
using ConsoleApp2.codewar;
using ConsoleApp2.algo;

namespace ConsoleApp2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //select_many.SetectManyEx();
            //BouncingBall.Start();
            //fib_set.Start();
            var res = fib_dpa.fib(3);
            Console.WriteLine(res);

        }
    }
}