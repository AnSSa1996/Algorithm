using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backj
{
    internal class Program
    {
        private static int MAX_VALUE = 100000;
        private static int[,] board;
        private static bool[,] visited;
        private static int?[,] dp;
        private static int Y;
        private static int X;
        private static int[] dy = { 0, 0, 1, -1 };
        private static int[] dx = { 1, -1, 0, 0 };
        private static int result = 0;

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            var inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            Y = inputs[0];
            X = inputs[1];

            board = new int[Y, X];
            dp = new int?[Y, X];
            visited = new bool[Y, X];

            for (var i = 0; i < Y; i++)
            {
                var line = sr.ReadLine().ToCharArray();
                for (var j = 0; j < X; j++)
                {
                    if (line[j] == 'H')
                        board[i, j] = 0;
                    else
                        board[i, j] = line[j] - '0';
                }
            }


            result = DFS(0, 0);
            if (result >= MAX_VALUE) result = -1;
            sw.WriteLine(result);
            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static int DFS(int y, int x)
        {
            if (y < 0 || y >= Y || x < 0 || x >= X || board[y, x] == 0) return 0;
            if (visited[y, x]) return MAX_VALUE;
            if (dp[y, x] != null) return dp[y, x].Value;

            visited[y, x] = true;
            var maxMove = 0;
            for (var i = 0; i < 4; i++)
            {
                var ny = y + dy[i] * board[y, x];
                var nx = x + dx[i] * board[y, x];
                maxMove = Math.Max(maxMove, DFS(ny, nx) + 1);
            }

            visited[y, x] = false;
            dp[y, x] = maxMove;
            return maxMove;
        }
    }
}