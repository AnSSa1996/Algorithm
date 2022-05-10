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

            int heavy = int.Parse(sr.ReadLine());

            List<int> nums = new List<int>();
            int sum = 1;
            nums.Add(sum);

            int[] dp = Enumerable.Repeat(1000, heavy + 1).ToArray();
            for (int i = 2; sum <= heavy; i++)
            {
                sum += i * (i + 1) / 2;
                nums.Add(sum);
            }

            for (int i = 1; i <= heavy; i++)
            {
                foreach (int num in nums)
                {
                    if (i == num) { dp[i] = 1; break; }
                    else if (i > num) { dp[i] = Math.Min(dp[i], dp[i - num] + 1); }
                }
            }

            sw.WriteLine(dp[heavy]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
