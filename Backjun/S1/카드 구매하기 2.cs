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
            List<int> nums = new List<int>();
            nums.Add(0);
            nums.AddRange(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());

            int[] dp = new int[N + 1];

            for (int a = 1; a < N + 1; a++)
            {
                for (int b = 1; b < a + 1; b++)
                {
                    if (dp[a] == 0) { dp[a] = dp[a - b] + nums[b]; }
                    else { dp[a] = Math.Min(dp[a], dp[a - b] + nums[b]); }
                }
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}