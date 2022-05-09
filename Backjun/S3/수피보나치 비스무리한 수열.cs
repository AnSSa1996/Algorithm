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

            long[] Dp = new long[N + 3];
            Dp[0] = 1; Dp[1] = 1; Dp[2] = 1;

            for (int i = 3; i <= N; i++) Dp[i] = Dp[i - 1] + Dp[i - 3];

            sw.WriteLine(Dp[N - 1]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
