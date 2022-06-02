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
            int[,] dp = new int[N, 10];

            for (int i = 0; i < 10; i++) dp[0, i] = 1;

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k <= j; k++)
                    {
                        dp[i, j] += dp[i - 1, k];
                    }
                    dp[i, j] %= 10007;
                }
            }

            long total = 0;
            for (int i = 0; i < 10; i++) total += dp[N - 1, i];

            sw.WriteLine(total % 10007);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
