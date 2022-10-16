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
            int N = inputs[0]; int M = inputs[1];
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList());
            List<(int Y, int X)> cloudLst = new List<(int Y, int X)>();
            cloudLst.Add((N - 1, 0)); cloudLst.Add((N - 1, 1)); cloudLst.Add((N - 2, 0)); cloudLst.Add((N - 2, 1));
            for (int i = 0; i < M; i++)
            {
                List<(int Y, int X)> nextCloudLst = new List<(int Y, int X)>();
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int d = inputs[0]; int s = inputs[1];
                bool[,] visitedCloud = new bool[N, N];
                int[] dx = new int[9] { 0, -1, -1, 0, 1, 1, 1, 0, -1 };
                int[] dy = new int[9] { 0, 0, -1, -1, -1, 0, 1, 1, 1 };

                foreach (var cloud in cloudLst)
                {
                    var nextX = cloud.X + dx[d] * s;
                    var nextY = cloud.Y + dy[d] * s;

                    nextX %= N;
                    nextY %= N;

                    if (nextX < 0) nextX = N + nextX;
                    if (nextY < 0) nextY = N + nextY;

                    board[nextY][nextX] += 1;
                    nextCloudLst.Add((nextY, nextX));
                    visitedCloud[nextY, nextX] = true;
                }

                int[] diagonalX = new int[4] { -1, -1, 1, 1 };
                int[] diagonalY = new int[4] { -1, 1, -1, 1 };
                foreach (var cloud in nextCloudLst)
                {
                    for (int e = 0; e < 4; e++)
                    {
                        var nextX = cloud.X + diagonalX[e];
                        var nextY = cloud.Y + diagonalY[e];

                        if (nextX < 0 | nextX >= N || nextY < 0 || nextY >= N) continue;
                        if (board[nextY][nextX] == 0) continue;
                        board[cloud.Y][cloud.X] += 1;
                    }
                }

                nextCloudLst.Clear();

                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < N; x++)
                    {
                        if (board[y][x] < 2) continue;
                        if (visitedCloud[y, x]) continue;
                        board[y][x] -= 2;
                        nextCloudLst.Add((y, x));
                    }
                }

                cloudLst = nextCloudLst;
            }

            sw.WriteLine(board.Sum(x => x.Sum()));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
