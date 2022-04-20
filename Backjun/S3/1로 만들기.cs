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
            int[] dp = new int[N + 4];

            dp[1] = 0;
            dp[2] = 1;
            dp[3] = 1;

            for (int i = 4; i <= N; i++)
            {
                List<int> temp = new List<int>();
                temp.Add(dp[i - 1] + 1);
                if (i % 3 == 0) temp.Add(dp[i / 3] + 1);
                if (i % 2 == 0) temp.Add(dp[i / 2] + 1);
                dp[i] = temp.Min();
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
