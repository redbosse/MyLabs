using System;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static double slag, sum, x,buffx;
        static int k, n;

        static double Recurse(int curr) {

            if (curr < 1) return buffx;

            return Recurse(curr-1) * x / ((2 * curr) * (2 * curr + 1));
        }
        static double Recurce2(int curr) {

            if (curr < 1) return buffx;


            return Recurce2(curr-1) + Recurse(curr);
        }
        static void Main(string[] args)
        {
            string[] buff = Console.ReadLine().Split(' ');

            k = Convert.ToInt32(buff[0]);
            x = Convert.ToDouble(buff[1]);
            slag = x;
            sum = x;
            buffx = x;
            x = x * x;
            


            Console.WriteLine(Recurce2(k-1));
            Console.ReadKey();
        }
    }
}
