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
            long[] dp = new long[N + 2];
            dp[1] = 1; dp[2] = 1;

            for (int i = 3; i <= N; i++) dp[i] = dp[i - 1] + dp[i - 2];

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}