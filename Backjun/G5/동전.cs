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

            int T = int.Parse(sr.ReadLine());
            for (int t = 0; t < T; t++)
            {
                int N = int.Parse(sr.ReadLine());
                int[] coins = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int V = int.Parse(sr.ReadLine());
                int[] dp = new int[V + 1];

                dp[0] = 1;

                foreach (var coin in coins)
                {
                    for (int v = 1; v <= V; v++)
                    {
                        if (v - coin < 0) continue;
                        dp[v] += dp[v - coin];
                    }
                }

                sw.WriteLine(dp[V]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}