using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            int[] dp = new int[N + 1];

            for (int i = 1; i <= N; i++)
            {
                dp[i] = nums[i - 1];
                for (int j = 1; j < i; j++)
                {
                    if (dp[i] < dp[i - j] + dp[j])
                    {
                        dp[i] = dp[i - j] + dp[j];
                    }
                }
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
