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
            List<List<int>> dp = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                dp.Add(lst);
            }

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0) { dp[i][j] += dp[i - 1][j]; continue; }
                    if (j == i) { dp[i][j] += dp[i - 1][j - 1]; continue; }

                    dp[i][j] += Math.Max(dp[i - 1][j - 1], dp[i - 1][j]);
                }
            }

            sw.WriteLine(dp[N - 1].Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}