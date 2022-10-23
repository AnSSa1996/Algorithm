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
            List<int> left = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            List<int> right = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            int[,] dp = new int[N + 1, N + 1];

            // 왼쪽 카드
            for (int i = N - 1; i >= 0; i--)
            {
                // 오른쪽 카드
                for (int j = N - 1; j >= 0; j--)
                {
                    if (right[j] < left[i])
                        dp[i, j] = Math.Max(dp[i, j + 1] + right[j], Math.Max(dp[i + 1, j], dp[i + 1, j + 1]));
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i + 1, j + 1]);
                }
            }

            sw.WriteLine(dp[0, 0]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
