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
            int[,] nums = new int[N, 3];
            int[,] dp = new int[N, 3];
            for (int i = 0; i < N; i++)
            {
                int[] inputNums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                nums[i, 0] = inputNums[0];
                nums[i, 1] = inputNums[1];
                nums[i, 2] = inputNums[2];
            }

            dp[0, 0] = nums[0, 0]; dp[0, 1] = nums[0, 1]; dp[0, 2] = nums[0, 2];

            for (int i = 1; i < N; i++)
            {
                dp[i, 0] = Math.Min(nums[i, 0] + dp[i - 1, 1], nums[i, 0] + dp[i - 1, 2]);
                dp[i, 1] = Math.Min(nums[i, 1] + dp[i - 1, 0], nums[i, 1] + dp[i - 1, 2]);
                dp[i, 2] = Math.Min(nums[i, 2] + dp[i - 1, 0], nums[i, 2] + dp[i - 1, 1]);
            }

            int min = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                if (min > dp[N - 1, i]) min = dp[N - 1, i];
            }

            sw.WriteLine(min);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
