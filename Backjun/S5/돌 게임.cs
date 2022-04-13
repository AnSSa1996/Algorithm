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

            bool[] dp = new bool[1001];

            dp[1] = true;
            dp[2] = false;
            dp[3] = true;

            int N = int.Parse(sr.ReadLine());

            for (int i = 4; i <= N; i++)
            {
                if (dp[i - 3] == true || dp[i - 1] == true) dp[i] = false;
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
