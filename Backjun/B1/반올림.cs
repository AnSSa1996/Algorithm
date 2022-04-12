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

            int N = int.Parse(sr.ReadLine());

            int digit = 1;
            while (true)
            {
                if (N <= Math.Pow(10, digit)) break;
                else
                {
                    N = Round(N, digit);
                    digit++;
                }
            }

            sw.WriteLine(N);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int Round(int value, int digit)
        {
            double mutiply = Math.Pow(10, digit);
            double d = (double)value / mutiply;
            return (int)(Math.Round(d, MidpointRounding.AwayFromZero) * mutiply);
        }
    }
}