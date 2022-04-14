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
            int C = inputs[0];
            int K = inputs[1];

            int[,] Dp = new int[31, 31];

            for (int c = 1; c <= C; c++)
            {
                for (int k = 1; k <= c; k++)
                {
                    if (k == 1) Dp[c, k] = 1;
                    else if (c == k) Dp[c, k] = 1;
                    else
                    {
                        Dp[c, k] = Dp[c - 1, k - 1] + Dp[c - 1, k];
                    }
                }
            }

            sw.WriteLine(Dp[C, K]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
