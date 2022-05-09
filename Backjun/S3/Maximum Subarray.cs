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

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int[] dp = new int[N];
                dp[0] = nums[0];

                for (int j = 1; j < N; j++)
                {
                    if (dp[j - 1] > 0) dp[j] = dp[j - 1] + nums[j];
                    else dp[j] = nums[j];
                }

                sw.WriteLine(dp.Max()); 
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
