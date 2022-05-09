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

            if (N >= 0)
            {
                long[] P_dp = new long[N + 5];
                P_dp[0] = 0; P_dp[1] = 1; P_dp[2] = 1;

                for (int i = 3; i <= N; i++)
                {
                    P_dp[i] = P_dp[i - 1] % 1000000000 + P_dp[i - 2] % 1000000000;
                }
                if (N == 0) { sw.WriteLine(0); sw.WriteLine(0); }
                else { sw.WriteLine(1); sw.WriteLine(P_dp[N] % 1000000000); }
            }
            else
            {
                N *= -1;
                long[] N_dp = new long[N + 5];
                N_dp[0] = 0; N_dp[1] = 1; N_dp[2] = -1;

                for (int i = 3; i <= N; i++)
                {
                    N_dp[i] = N_dp[i - 2] % 1000000000 - N_dp[i - 1] % 1000000000;
                }
                if (N % 2 == 0) { sw.WriteLine(-1); sw.WriteLine(Math.Abs(N_dp[N]) % 1000000000); }
                else { sw.WriteLine(1); sw.WriteLine(N_dp[N] % 1000000000); }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
