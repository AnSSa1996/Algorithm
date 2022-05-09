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

            bool[] dp = new bool[N + 5];
            dp[1] = true; dp[2] = false; dp[3] = true; dp[4] = true;

            for (int i = 5; i <= N; i++)
            {
                if (dp[i - 1] && dp[i - 3] && dp[i - 4]) dp[i] = false;
                else dp[i] = true;
            }

            if (dp[N]) sw.WriteLine("SK");
            else sw.WriteLine("CY");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
