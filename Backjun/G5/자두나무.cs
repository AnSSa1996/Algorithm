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
            int T = inputs[0]; int W = inputs[1];
            int[,] dp = new int[T + 1, W + 1];
            List<int> board = new List<int>();
            for (int i = 0; i < T; i++) board.Add(int.Parse(sr.ReadLine()));

            for (int i = 1; i <= T; i++)
            {
                int applePos = board[i - 1];

                if (applePos == 1)
                    dp[i, 0] = dp[i - 1, 0] + 1;
                else
                    dp[i, 0] = dp[i - 1, 0];

                for (int j = 1; j <= W; j++)
                {
                    if (j > i) break;

                    if (applePos == 1 && j % 2 == 0)
                        dp[i, j] = Math.Max(dp[i - 1, j - 1], dp[i - 1, j]) + 1;
                    else if (applePos == 2 && j % 2 == 1)
                        dp[i, j] = Math.Max(dp[i - 1, j - 1], dp[i - 1, j]) + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j - 1], dp[i - 1, j]);
                }
            }

            int result = 0;
            for (int w = 0; w <= W; w++)
            {
                if (result < dp[T, w]) result = dp[T, w];
            }
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
