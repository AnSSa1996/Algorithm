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
            int[] dp = Enumerable.Repeat(10000, N).ToArray();
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            dp[0] = 1;
            for (int i = 0; i < N; i++)
            {
                if (dp[i] == 0 && i != 1) continue;
                else
                {
                    int jump = nums[i];
                    for (int j = 1; j <= jump; j++)
                    {
                        if (i + j >= N) break;
                        if (dp[i + j] > dp[i] + 1)
                            dp[i + j] = dp[i] + 1;
                    }
                }
            }
            if (dp.Count() == 1) sw.WriteLine(0);
            else if (dp[N - 1] - 1 <= 0 || dp[N - 1] == 10000) sw.WriteLine(-1);
            else sw.WriteLine(dp[N - 1] - 1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}