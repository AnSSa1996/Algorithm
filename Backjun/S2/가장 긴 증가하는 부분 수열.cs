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
            int[] dp = new int[N];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dp[i] < dp[j] && nums[i] > nums[j]) { dp[i] = dp[j]; }
                }
                dp[i] += 1;
            }

            sw.WriteLine(dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}