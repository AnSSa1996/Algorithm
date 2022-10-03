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
            long[,] dp = new long[N + 1, 21];

            dp[0, nums[0]] = 1;

            for (int index = 1; index < nums.Length; index++)
            {
                for (int num = 0; num <= 20; num++)
                {
                    if (dp[index - 1, num] == 0) continue;

                    if (num + nums[index] <= 20)
                    {
                        dp[index, num + nums[index]] += dp[index - 1, num];
                    }
                    if (num - nums[index] >= 0)
                    {
                        dp[index, num - nums[index]] += dp[index - 1, num];
                    }
                }
            }

            sw.WriteLine(dp[N - 2, nums[nums.Length - 1]]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}