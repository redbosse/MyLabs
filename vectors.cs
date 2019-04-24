using System;
using System.IO;



namespace ConsoleApp1
{
    class Program
    {


        static int Func(int[] mass,int size) {

            int var = -1;

            for (int i = 1; i < size-1; i++) {
                if ((mass[i - 1] < mass[i]) && (mass[i] > mass[i + 1])) {
                    var = i + 1;
                    break;
                }

            }

            return var;
        }


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"Inlet.in");



            int length = Convert.ToInt32(sr.ReadLine());
            string[] str2 = sr.ReadLine().Split(' ');
            sr.Close();

            int[] mass = new int[length];

            for (uint i = 0; i < length; i++) {
                mass[i] = Convert.ToInt32(str2[i]);

              //  Console.WriteLine(mass[i]);
            }





           // Console.WriteLine(Func(mass,str2.Length-1));

            StreamWriter sw = new StreamWriter(@"Outlet.out");
            sw.Write(Func(mass, str2.Length));
            sw.Close();
        }
    }
}
