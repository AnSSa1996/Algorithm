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
            int M = int.Parse(sr.ReadLine());

            List<int> nums = new List<int>();
            for (int i = 0; i < M; i++) nums.Add(int.Parse(sr.ReadLine()));

            long[] dp = new long[N + 3];

            dp[0] = 1; dp[1] = 1; dp[2] = 2;
            for (int i = 2; i <= N; i++) dp[i] = dp[i - 1] + dp[i - 2];


            if (M == 0) sw.WriteLine(dp[N]);
            else
            {
                long answer = 1;
                int preNum = 0;
                for (int index = 0; index < M; index++)
                {
                    answer *= dp[nums[index] - preNum - 1];
                    preNum = nums[index];
                }

                answer *= dp[N - preNum];

                sw.WriteLine(answer);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}