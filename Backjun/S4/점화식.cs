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

            BigInteger[] dp = new BigInteger[36];

            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 2;
            int N = int.Parse(sr.ReadLine());
            for (int i = 3; i <= N; i++)
            {
                BigInteger sum = 0;
                for (int j = 0; j < i; j++) sum += dp[j] * dp[i - j - 1];
                dp[i] = sum;
            }

            sw.WriteLine(dp[N]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}

