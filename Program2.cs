using System;
using System.IO;

namespace ConsoleApp1
{

    class Vector {

        int P;
        int n;
        public double[] A;

        public Vector() {
            string[] str = File.ReadAllLines(@"Inlet.in");

            n = Convert.ToInt32(str[0].Split(' ')[0]);
            P = Convert.ToInt32(str[0].Split(' ')[1]);

            string[] buffstr = str[0].Split(' ');

            A = new double[buffstr.Length/2];

            for (int i = 0; i < buffstr.Length;i++) {

                if (i % 2) {
                    A[i] = Convert.ToDouble(buffstr[i - 1]) + Convert.ToDouble(buffstr[i]);
                }
            }
        }

        public void DeleteMax() {
            int maxindex = 0;
            int max = -999999;
            for (int i = 0; i < A.Length;i++) {

                if (A[i] > max) {
                    max = A[i];
                    maxindex = i;
                }

            }
            Array.Clear(A,maxindex,1);
        }
        public double[] NoUnicalMass() {

            double[] B;
            int counter = 0;
            int counterB = 0;
            foreach (int i in A) {
                foreach (int j in A)
                {
                    if (A[i] == A[j]) {

                        counter++;
                    }
                }
                if (counter > 1) {
                    B = new double[1];
                    B[counterB] = A[i];
                    counterB++;
                }
            }
            return B;
        }
        public int CountPAR() {
            int counts = 0;
            for(int i = 1; i < A.Length;i++) {

                if ((Convert.ToInt32(A[i-1])+Convert.ToInt32(A[i])) % P == 0) {
                    counts++;
                }

            }
            return 0;
        }
        public double CountABSElem() {
            double maxelem = 0;
            for (int i = 1; i < A.Length; i+=2)
            {
                if (Math.Abs(A[i]) > maxelem) {
                    maxelem = Math.Abs(A[i]);
                }

            }
            return maxelem;
        }
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Vector vec = new Vector();

            StreamWriter sr = new StreamWriter(@"Outlet.out");

            for (int i = 0; i < vec.A.Length; i++)
            {
                sr.WriteLine(vec.A[i]);
            }
            sr.Close();
        }
    }
}
