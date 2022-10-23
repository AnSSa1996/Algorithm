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
            long[] dp = new long[N + 1];
            for (int i = 1; i <= N; i++) dp[i] = i;
            for (int i = 7; i <= N; i++)
            {
                dp[i] = Math.Max(dp[i - 3] * 2, Math.Max(dp[i - 4] * 3, dp[i - 5] * 4));
            }


            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
