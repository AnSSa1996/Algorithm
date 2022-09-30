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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int V = inputs[1];
            List<int> cointLst = new List<int>();
            int[] dp = new int[V + 1];
            for (int i = 0; i < N; i++)
            {
                int C = int.Parse(sr.ReadLine());
                if (C > V) continue;
                dp[C] = 1;
                cointLst.Add(C);
            }

            for (int i = 1; i <= V; i++)
            {
                foreach (var coin in cointLst)
                {
                    if (i - coin < 0) continue;
                    if (dp[i - coin] == 0) continue;
                    if (dp[i] == 0) { dp[i] = dp[i - coin] + 1; continue; }
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);

                }
            }

            if (dp[V] == 0) sw.WriteLine(-1);
            else sw.WriteLine(dp[V]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}