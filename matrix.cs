using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace ConsoleApp1
{
    class Program
    {
       

        static int[][] Func(int[][] mass,int size) {




            int[][] num = new int[size][];
            for (uint i = 0; i < size; i++)
            {
                num[i] = new int[size];
            }
            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    num[i][j] = mass[i][j];
                }
            }

            int temp;
            for (uint i = 0; i < size; i++)
            {
                for (uint j = i; j < size; j++)
                {
                    temp = mass[i][j];
                    mass[i][j] = mass[j][i];
                    mass[j][i] = temp;
                }
            }

            for (uint k = 0; k < size; k++)
            {
                int i = 0, j = size - 1;

                while (i <= j)
                {
                    temp = mass[k][i];
                    mass[k][i] = mass[k][j];
                    mass[k][j] = temp;
                    i++;
                    j--;
                }
            }
            for (uint i = 1; i < size - 1; i++)
            {
                for (uint j = 1; j < size - 1; j++)
                {
                    mass[i][j] = num[i][j];
                }
            }


            return mass;
        }


        static void Main(string[] args)
        {
             StreamReader sr = new StreamReader(@"Inlet.in");

            int length = Convert.ToInt32(sr.ReadLine());
            int[][] mass = new int[length][];

            
            for (int i = 0; i < length; i++)
            {
                string[] str = sr.ReadLine().Split(' ');
                mass[i] = new int[length];

                for (int j = 0; j < length; j++)
                {
                    mass[i][j] = Convert.ToInt32(str[j]);
                }
            }

                
         



           int[][] write = Func(mass,length);



            StreamWriter sw = new StreamWriter(@"Outlet.out");
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    sw.Write(write[i][j]);
                    sw.Write(' ');
                }
               if(i != length-1) sw.WriteLine();
            }
           
            sw.Close();
           // Console.ReadKey();
        }
    }
}
