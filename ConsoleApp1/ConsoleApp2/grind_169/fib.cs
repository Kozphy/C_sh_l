namespace fib;
    
using static System.Console;

public class fib_set {
    public static void fib_execute(){
        WriteLine("using recursive with fib");
        Write("Please input integer: ");
        int num;
        string str;
        str = ReadLine();
        num = int.Parse(str);
        if (num < 0)
            WriteLine("input number must bigger than 0");
        else
            Write("Fac(" + num + ")=" + fac(num) + "," + "fib_n_sum= " + fib_n_sum(num));
    }

    static int fac(int n)
    {
        if (n == 1){
            return  1;
        }
        return n * fac(n-1);
    }

    static int fib_n_sum(int n)
    {
        if (n==0){
            return 0;
        }else if(n==1){
            return 1;
        }
        // 2 -> [1,0], 1
        return fib_n_sum(n-1) + fib_n_sum(n-2);
    }

}

