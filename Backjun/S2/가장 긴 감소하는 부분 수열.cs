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
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int[] dp = new int[N];

            dp[0] = 1;
            for (int i = 1; i < N; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (dp[i] < (dp[j] + 1) && nums[i] < nums[j])
                        dp[i] = dp[j] + 1;
                }
            }

            sw.WriteLine(dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}