using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;

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

            int[,] dp = new int[2, N];
            dp[0, 0] = nums[0];
            int ans = int.MinValue;
            for (int i = 1; i < N; i++)
            {
                dp[0, i] = Math.Max(dp[0, i - 1] + nums[i], nums[i]);
                dp[1, i] = Math.Max(dp[0, i - 1], dp[1, i - 1] + nums[i]);
                ans = Math.Max(ans, Math.Max(dp[0, i], dp[1, i]));
            }

            if (N != 1) sw.WriteLine(ans);
            else sw.WriteLine(nums[0]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}