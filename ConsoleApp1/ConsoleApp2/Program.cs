
using ConsoleApp2.grind_169;
using ConsoleApp2.test_fun;
using System.ComponentModel;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // leetcodeResult();
            fib.fib_set.fib_execute();
        }
        private static void leetcodeResult()
        {
            /**
            Valid_Para_20 vp20 = new Valid_Para_20();
            Console.WriteLine(vp20.get_result());
            **/

            /**
            Merge_two_sorted_list_21 mtsl21 = new Merge_two_sorted_list_21();
            mtsl21.GetResult();
            **/

            //Best_Time_121 bt121 = new Best_Time_121();
            //bt121.GetResult();

            /*
            Valid_pali_125 vp125 = new Valid_pali_125();
            vp125.GetResult();
            */

            Invert_bin_226 ib226 = new Invert_bin_226();
            ib226.GetResult();
        }

        private static void shadow_copy() { 
            test_fun 
        }

        private static void StaticModifier()
        {
            Statics s = new Statics();
            Console.WriteLine(Statics.bookCount);
            Console.WriteLine(s.getBookCount());

            /*
            Console.WriteLine(Math.Sqrt(144));
            UsefulTools.SayHi("123");
            Console.ReadLine();
            */
        }

        private static void Inheritance()
        {
            /*
            Chef chef = new Chef();
            chef.MakeChicken();
            chef.MakeSpecialDish();

            ItalianChef italianChef = new ItalianChef();
            italianChef.MakeChicken();
            italianChef.MakePasta();
            italianChef.MakeSpecialDish();
            Console.ReadLine();
            */
        }


    }
}