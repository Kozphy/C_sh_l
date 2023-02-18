using System;
using ConsoleApp1.grind_169;

namespace Program
{
    class ArrayExample
    {
        static void Main()
        {
            TwoSum ts =  new TwoSum();
            
            Console.WriteLine(ts.caculate());
            Console.Read();
        }
    }

    public class Pair<TFirst, TSecond>
    { 
        public TFirst First { get; }
        public TSecond Second { get; }
        public Pair(TFirst first, TSecond second) => (First, Second) = (first, second);
    }

    public class Point
    { 
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Point3D : Point
    { 
        public int Z { get; set; }

        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }

}
