using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] dp = new int[N + 2];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= N; i++) dp[i] = dp[i - 1] % 1000000007 + dp[i - 2] % 1000000007;

            sw.WriteLine(dp[N] % 1000000007);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
