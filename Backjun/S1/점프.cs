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
            List<int[]> board = new List<int[]>();
            for (int i = 0; i < N; i++) board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse));

            long[,] dp = new long[N, N];
            dp[0, 0] = 1;

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    if (y == N - 1 && x == N - 1) break;
                    int right = x + board[y][x];
                    int down = y + board[y][x];

                    if (down < N) dp[down, x] += dp[y, x];
                    if (right < N) dp[y, right] += dp[y, x];
                }
            }

            sw.WriteLine(dp[N - 1, N - 1]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}