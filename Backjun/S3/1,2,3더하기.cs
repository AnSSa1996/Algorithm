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
            int[] dp = new int[12];

            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;

            for (int i = 4; i < 12; i++) dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                sw.WriteLine(dp[num]);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
