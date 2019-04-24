using System;


namespace ConsoleApp1
{
    class Program
    {
        static double MyFunc(double a) {
        return (a * a * a * a) - 3 * (a * a) + 75 * a - 10000;
        }
        static double MyDev(double a)
        {
            return 4 * (a * a * a) - 6 * a + 75;
        }
        static double My2Dev(double a)
        {
            return 12 * (a * a) - 6;
        }
        static double TangensMethod(double a,double b) {

            if (MyFunc(a) * My2Dev(a) > 0)
                return a;
            else
                return b;
        }
        static double reshenieZadachi(double a,double b,double tochnost) {
            double x;
            
                x = TangensMethod(a, b);

            while (Math.Abs((x - MyFunc(x) / MyDev(x)) - x) > tochnost)
                x = x - MyFunc(x) / MyDev(x);
            return x;

         }


        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');
            double a ,b, eps,cor,x;
          
            a = Convert.ToDouble(str[0]);
            b = Convert.ToDouble(str[1]);
            eps = Convert.ToDouble(str[2]);

            cor = reshenieZadachi(a,b,eps);

            Console.WriteLine(cor);
            Console.ReadKey();

        }
    }
}
