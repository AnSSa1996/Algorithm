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
            int[] powers = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] dp = new int[N];

            for (int i = 0; i < N; i++)
            {
                int max = 0;
                for (int j = 0; j < i; j++)
                {
                    if (powers[j] > powers[i] && dp[j] > max)
                    {
                        max = dp[j];
                    }
                }
                dp[i] = max + 1;
            }

            sw.WriteLine(N - dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}