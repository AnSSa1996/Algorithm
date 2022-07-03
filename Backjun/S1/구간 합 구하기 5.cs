using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJun
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0]; int T = inputs[1];
            int[,] dp = new int[N + 1, N + 1];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) { board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList()); }

            for (int x = 0; x < N; x++)
            {
                for (int y = 0; y < N; y++)
                {
                    dp[x + 1, y + 1] = dp[x + 1, y] + dp[x, y + 1] - dp[x, y] + board[x][y];
                }
            }

            for (int i = 0; i < T; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int x1 = inputs[0]; int y1 = inputs[1]; int x2 = inputs[2]; int y2 = inputs[3];

                int result = dp[x2, y2] - (dp[x1 - 1, y2] + dp[x2, y1 - 1]) + dp[x1 - 1, y1 - 1];
                sw.WriteLine(result);
            }


            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
