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
            long[] Dp = new long[N + 10];
            Dp[0] = 0;
            Dp[1] = 1;

            for (long i = 2; i <= N; i++) Dp[i] = Dp[i - 1] + Dp[i - 2];
            sw.WriteLine(Dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}