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

            List<int> sqaure = new List<int>();
            for (int i = 1; i * i <= 120000; i++) sqaure.Add(i * i);

            int N = int.Parse(sr.ReadLine());
            int[] dp = new int[N + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= N; i++)
            {
                List<int> minList = new List<int>();
                for (int j = 0; sqaure[j] <= i; j++) { minList.Add(dp[i - sqaure[j]]); }
                dp[i] = minList.Min() + 1;
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}