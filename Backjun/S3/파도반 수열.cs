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

            int T = int.Parse(sr.ReadLine());
            long[] dp = new long[102];
            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 1;

            for (int i = 4; i <= 101; i++) dp[i] = dp[i - 2] + dp[i - 3];
            for (int i = 0; i < T; i++) sw.WriteLine(dp[int.Parse(sr.ReadLine())]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}