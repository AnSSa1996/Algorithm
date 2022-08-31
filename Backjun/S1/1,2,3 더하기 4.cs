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

            int repeat = int.Parse(sr.ReadLine());
            int[] dp = new int[10001];

            dp[0] = 0; dp[1] = 1; dp[2] = 2; dp[3] = 3; dp[4] = 4;

            for (int i = 4; i <= 10000; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2] - dp[i - 3];
                if (i % 3 == 0) dp[i] += 1;
            }

            for (int i = 0; i < repeat; i++)
            {
                int N = int.Parse(sr.ReadLine());
                sw.WriteLine(dp[N]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
