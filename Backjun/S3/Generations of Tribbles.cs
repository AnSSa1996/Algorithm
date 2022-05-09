using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int T = int.Parse(sr.ReadLine());

            BigInteger[] dp = new BigInteger[69];
            dp[0] = 1; dp[1] = 1; dp[2] = 2; dp[3] = 4;

            for (int i = 4; i <= 68; i++) dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3] + dp[i - 4];

            for (int i = 0; i < T; i++)
            {
                int index = int.Parse(sr.ReadLine());
                sw.WriteLine(dp[index]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
