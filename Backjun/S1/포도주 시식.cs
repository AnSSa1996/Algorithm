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
            List<int> nums = new List<int>();
            for (int i = 0; i < N; i++) nums.Add(int.Parse(sr.ReadLine()));
            int[] dp = new int[N];

            for (int i = 0; i < N; i++)
            {
                if (i == 0) { dp[0] = nums[0]; continue; }
                if (i == 1) { dp[1] = nums[0] + nums[1]; continue; }

                int dpI_2 = 0;
                int dpI_3 = 0;
                int dpI_4 = 0;
                if (i - 2 >= 0) dpI_2 = dp[i - 2];
                if (i - 3 >= 0) dpI_3 = dp[i - 3];
                if (i - 4 >= 0) dpI_4 = dp[i - 4];

                List<int> lst = new List<int>();
                lst.Add(nums[i] + nums[i - 1] + dpI_3);
                lst.Add(nums[i] + nums[i - 1] + dpI_4);
                lst.Add(nums[i] + dpI_2);
                dp[i] = lst.Max();
            }

            sw.WriteLine(dp.Max());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}