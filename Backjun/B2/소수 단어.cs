using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            string str = sr.ReadLine();

            long sum = str.ToArray().Sum(x => x >= 'a' ? x - 'a' + 1 : x - 'A' + 27);

            if (isSosu(sum)) sw.WriteLine("It is a prime word.");
            else sw.WriteLine("It is not a prime word.");

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static bool isSosu(long N)
        {
            if (N == 0) return false;
            if (N == 1) return true;
            if (N == 2) return true;
            for (long i = 2; i * i <= N; i++)
            {
                if (N % i == 0) return false;
            }
            return true;
        }
    }
}