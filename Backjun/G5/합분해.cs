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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int K = inputs[1];
            int[,] dp = new int[N + 1, K + 1];

            for (int n = 1; n <= N; n++)
            {
                for (int k = 1; k <= K; k++)
                {
                    if (n == 1) { dp[n, k] = k; continue; }
                    if (k == 1) { dp[n, k] = 1; continue; }

                    dp[n, k] = (dp[n, k - 1] + dp[n - 1, k]) % 1000000000;
                }
            }

            sw.WriteLine(dp[N, K]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}