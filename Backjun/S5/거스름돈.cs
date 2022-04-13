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

            List<int> dp = new List<int>();

            dp.Add(-1); dp.Add(-1); dp.Add(1); dp.Add(-1); dp.Add(2); dp.Add(1);

            int N = int.Parse(sr.ReadLine());
            for (int i = 6; i <= N; i++)
            {
                int min = int.MaxValue;
                if (dp[i - 5] >= 0) min = Math.Min(min, dp[i - 5] + 1);
                if (dp[i - 2] >= 0) min = Math.Min(min, dp[i - 2] + 1);

                if (min == int.MaxValue) dp.Add(-1);
                else dp.Add(min);
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
