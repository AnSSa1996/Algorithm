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
            int[] stairs = new int[N + 1];

            for (int i = 1; i <= N; i++) stairs[i] = int.Parse(sr.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                if (i == 1) { dp[1] = stairs[1]; continue; }
                if (i == 2) { dp[2] = stairs[1] + stairs[2]; continue; }

                int first = stairs[i] + stairs[i - 1] + dp[i - 3];
                int second = stairs[i] + dp[i - 2];
                dp[i] = Math.Max(first, second);
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}