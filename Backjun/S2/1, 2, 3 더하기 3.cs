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
            long[] dp = new long[1000001];
            dp[1] = 1; dp[2] = 2; dp[3] = 4;

            for (int i = 4; i <= 1000000; i++) dp[i] = dp[i - 1] % 1000000009 + dp[i - 2] % 1000000009 + dp[i - 3] % 1000000009;

            for (int i = 0; i < T; i++) { int N = int.Parse(sr.ReadLine()); sw.WriteLine(dp[N] % 1000000009); }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}