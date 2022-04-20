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
            int[] dp = new int[N + 1];
            dp[0] = 1;
            dp[1] = 2;

            for (int i = 2; i <= N; i++) dp[i] = dp[i - 1] % 10 + dp[i - 2] % 10;

            sw.WriteLine(dp[N - 1] % 10);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
