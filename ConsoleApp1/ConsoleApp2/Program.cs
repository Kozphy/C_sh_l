namespace ConsoleApp2
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            int? x = null;
            Console.WriteLine(x);
            int y;
            y = x ?? -1;
            Console.WriteLine(y);
            float cTemp, fTemp;
        }
    }
}