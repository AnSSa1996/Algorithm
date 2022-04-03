using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        public static List<int> sosu = new List<int>();
        public static bool[] sosuCheck;
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string line = Console.ReadLine();
            var sp = line.Split(' ');

            BigInteger P = BigInteger.Parse(sp[0]);
            int K = int.Parse(sp[1]);

            sosuCheck = new bool[1000000000 + 1];
            Eratos(K);
            bool check = true;
            int checkSosu = 0;
            foreach (var s in sosu)
            {
                if (P % s == 0)
                {
                    check = false;
                    checkSosu = s;
                    break;
                }
            }

            if (check) sw.WriteLine("GOOD");
            else sw.WriteLine($"BAD {checkSosu}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void Eratos(int K)
        {
            for (int i = 2; i < K; i++)
            {
                if (sosuCheck[i] == false)
                {
                    sosu.Add(i);
                    for (int j = i; j <= K; j += i)
                    {
                        sosuCheck[j] = true;
                    }
                }
            }
        }
    }
}
