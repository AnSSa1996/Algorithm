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

            long[,] dp = new long[N, 10];
            for (int i = 1; i < 10; i++) dp[0, i] = 1;

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 0) { dp[i, j] = dp[i - 1, 1] % 1000000000; continue; }
                    if (j == 9) { dp[i, j] = dp[i - 1, 8] % 1000000000; continue; }
                    dp[i, j] = dp[i - 1, j - 1] % 1000000000 + dp[i - 1, j + 1] % 1000000000;
                }
            }

            long total = 0;
            for (int i = 0; i < 10; i++) { total += dp[N - 1, i]; }

            sw.WriteLine(total % 1000000000);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}