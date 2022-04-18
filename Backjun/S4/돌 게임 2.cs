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
            bool[] dp = new bool[N + 1];

            dp[1] = true;
            if (N >= 3) dp[3] = true;

            for (int i = 4; i <= N; i++)
            {
                if (dp[i - 1] == false) dp[i] = true;
                if (dp[i - 3] == false) dp[i] = true;
            }

            if (dp[N]) sw.WriteLine("CY");
            else sw.WriteLine("SK");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
