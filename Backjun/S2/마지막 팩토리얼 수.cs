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
            long[] dp = new long[N + 1];
            dp[1] = 1;

            for (int i = 2; i <= N; i++)
            {
                long num = dp[i - 1] * i;
                while (num % 10 == 0) num /= 10;
                dp[i] = num % 1000000;
            }

            sw.WriteLine(dp[N] % 10);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
