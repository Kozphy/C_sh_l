using System;

namespace ConsoleApp2.practice.nullable_p
{
   internal class nullable_start{
        public  static void Start()
        {
            int? num1 = null;
            int? num2 = 1337;

            double? num3 = new Double();
            double? num4 = 31715;

            bool? boolval = new bool?();
            System.Console.WriteLine($"Our nullable numbers are: {num1}, {num2}, {num3}, {num4}");
            System.Console.WriteLine($"The nullable boolean value is {boolval}");
        }
   } 
}