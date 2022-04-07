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
            int[] dp = Enumerable.Repeat(-1, N + 5).ToArray();

            dp[3] = 1;
            dp[5] = 1;

            for (int i = 6; i <= N; i++)
            {
                int min = int.MaxValue;
                if (dp[i - 3] != -1) min = Math.Min(min, dp[i - 3]) + 1;
                if (dp[i - 5] != -1) min = Math.Min(min, dp[i - 5]) + 1;
                if (min != int.MaxValue) dp[i] = min;
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}