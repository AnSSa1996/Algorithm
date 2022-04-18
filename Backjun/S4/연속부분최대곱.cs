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
            double[] dp = new double[N];
            dp[0] = double.Parse(sr.ReadLine());
            for (int i = 1; i < N; i++)
            {
                double d = double.Parse(sr.ReadLine());
                if (dp[i - 1] * d > d) dp[i] = dp[i - 1] * d;
                else dp[i] = d;
            }

            sw.WriteLine($"{Math.Round(dp.Max(), 3):f3}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
