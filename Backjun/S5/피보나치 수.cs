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

            BigInteger[] dp = new BigInteger[100001];

            dp[1] = 1;
            dp[2] = 1;

            int N = int.Parse(sr.ReadLine());

            for (int i = 3; i <= N; i++) dp[i] = dp[i - 1] + dp[i - 2];

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
