using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {

     
        static string Compute(string str,int length) {

            string buff = "";

            string[] str2 = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            

            for (int i = 0; i < str2.Length; i++) {

                if (str2[i].Length == length)
                {
                    buff += str2[i] + ' ';

                    int index = str.IndexOf(str2[i]);
                    str = str.Remove(index, length);
                } 
            }
            

            buff += str;


            return buff;
        }
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader(@"Inlet.in");

            string[] str = File.ReadAllLines(@"Inlet.in");

          

            int length = Convert.ToInt32(str[str.Length-1]);
           
            

           
            StreamWriter sw = new StreamWriter(@"Outlet.out");
            for (uint i = 0; i < str.Length-1; i++)
            {
                sw.Write(Compute(str[i], length));
                sw.WriteLine();
            }
           
            sw.Close();
        }
    }
}
