using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {

     
        static string Compute(string str) {

            char[] dop;
            char simv;
            int i;
            dop = str.ToCharArray();
            for (i = 0; i < (dop.Length / 2); i++)
            {
                simv = dop[i];
                dop[i] = dop[dop.Length - i - 1];
                dop[dop.Length - i - 1] = simv;

            }
            str = new string(dop);


            return str;
        }
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader(@"Inlet.in");

            string[] str = File.ReadAllLines(@"Inlet.in");

         

           
            StreamWriter sw = new StreamWriter(@"Outlet.out");
            for (uint i = 0; i < str.Length; i++)
            {
                sw.Write(Compute(str[i]));
                sw.WriteLine();
            }
           
            sw.Close();
        }
    }
}
