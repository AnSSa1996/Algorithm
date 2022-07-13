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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int S = inputs[1]; int M = inputs[2];
            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int[,] dp = new int[N + 1, M + 1];
            dp[0, S] = 1;
            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b <= M; b++)
                {
                    if (dp[a, b] == 1)
                    {
                        if (b + nums[a] <= M) dp[a + 1, b + nums[a]] = 1;
                        if (b - nums[a] >= 0) dp[a + 1, b - nums[a]] = 1;
                    }
                }
            }

            var result = -1;
            for (int i = 0; i <= M; i++) { if (dp[N, i] == 1) result = i; }

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}