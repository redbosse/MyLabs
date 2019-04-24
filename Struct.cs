using System;
using System.IO;

namespace ConsoleApp1
{

    struct Datas
    {
        Datas(int Hours, int min)
        {
            this.Hours = Hours;
            this.min = min;
        }
        public int Hours;
        public int min;
    }
    struct Train
    {

        public string SityPoint;
        public uint NumberTrain;
        public Datas TimeRace;
        public void SetDatas(int Hours,int min) {
            this.TimeRace.Hours = Hours;
            this.TimeRace.min = min;
        }
        public void SetData(string Sityname, uint NumberTrain, Datas time)
        {
            this.SityPoint = Sityname;
            this.NumberTrain = NumberTrain;
            this.TimeRace = time;
        }
    }

    class Program
    {


        static bool CompareDatas(Datas d1,Datas d2) {

            if (d1.Hours == d2.Hours) {
                if (d1.min > d2.min) {
                    return true;
                }
                return false;
            }
            if (d1.Hours > d2.Hours) {
                return true;
            }
            return false;
        }
        static Train[] Sortir(Train[] train) {

            int i = 0;
            Train buf;
            int swap_cnt = 0;

            if (train.Length - 1 == 0)
                return train;
            while (i < train.Length)
            {
                if (i + 1 != train.Length && CompareDatas(train[i].TimeRace,train[i+1].TimeRace))
                {
                    buf = train[i];
                    train[i] = train[i + 1];
                    train[i + 1] = buf;
                    swap_cnt = 1;
                }
                i++;
                if (i == train.Length && swap_cnt == 1)
                {
                    swap_cnt = 0;
                    i = 0;
                }
            }

            return train;
        }
        static void Main(string[] args)
        {
            Train trn;

            string[] str = File.ReadAllLines(@"Inlet.in");

            trn.NumberTrain = 0;
            trn.SityPoint = str[0];
            trn.TimeRace.Hours = Convert.ToInt32(str[1].Split(' ')[0]);
            trn.TimeRace.min = Convert.ToInt32(str[1].Split(' ')[1]);

            Train[] train = new Train[str.Length/3];

            int trainCounter = 0;
            for (uint i = 2; i < str.Length;i++) {

                if (i % 3 == 0) {
                 //   Console.WriteLine(str[i-1]);
                    train[trainCounter].SityPoint = str[i-1];
                    trainCounter++;
                }
            }
            trainCounter = 0;
            for (uint i = 2; i < str.Length-1; i++)
            {

                if (i % 3 == 0)
                {
                 //   Console.WriteLine(str[i]);
                    train[trainCounter].NumberTrain = Convert.ToUInt32(str[i]);
                    trainCounter++;
                }
            }
            trainCounter = 0;
            for (uint i = 2; i < str.Length - 2; i++)
            {

                if (i % 3 == 0)
                {
                //    Console.WriteLine(str[i + 1]);
                    train[trainCounter].SetDatas(Convert.ToInt32(str[i+1].Split(' ')[0]),Convert.ToInt32(str[i+1].Split(' ')[1]));
                    trainCounter++;
                }
            }
            Train[] newTrain = Sortir(train);
            StreamWriter sw = new StreamWriter(@"Outlet.out");
            for (uint i = 0; i < train.Length; i++)
            {
                sw.WriteLine(newTrain[i].SityPoint);
                sw.WriteLine(newTrain[i].NumberTrain);
                sw.WriteLine(newTrain[i].TimeRace.Hours + " " + newTrain[i].TimeRace.min);
            }


            for (uint i = 0; i < newTrain.Length;i++) {

                if (newTrain[i].SityPoint == trn.SityPoint)
                {

                    sw.WriteLine(newTrain[i].NumberTrain);
                    sw.Write(Math.Abs((newTrain[i].TimeRace.Hours - trn.TimeRace.Hours)) + " " + Math.Abs(newTrain[i].TimeRace.min - trn.TimeRace.min));

                }
           

            }

           
           
           
            sw.Close();
        }
    }
}
