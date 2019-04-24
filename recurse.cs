using System;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {

        static double Sum(double k,double eps) {

            if (eps > k) return 0;
            else
                return Math.Sqrt(3*eps + Sum(k,eps+1));
        }


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"Inlet.in");
            double k = Convert.ToDouble(sr.ReadLine());
            sr.Close();

            k = Sum(k,1);

            StreamWriter sw = new StreamWriter(@"Outlet.out");
            sw.Write(k);
            sw.Close();
        }
    }
}
