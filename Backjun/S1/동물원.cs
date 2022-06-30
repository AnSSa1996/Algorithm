using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            long N = long.Parse(sr.ReadLine());
            long[,] dp = new long[N, 3];
            dp[0, 0] = 1; dp[0, 1] = 1; dp[0, 2] = 1;

            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = (dp[i - 1, 0] + dp[i - 1, 1] + dp[i - 1, 2]) % 9901;
                dp[i, 1] = (dp[i - 1, 0] + dp[i - 1, 2]) % 9901;
                dp[i, 2] = (dp[i - 1, 0] + dp[i - 1, 1]) % 9901;
            }

            sw.WriteLine((dp[N - 1, 0] + dp[N - 1, 1] + dp[N - 1, 2]) % 9901);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
