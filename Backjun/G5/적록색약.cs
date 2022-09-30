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
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < N; i++) { board.Add(sr.ReadLine().ToArray().ToList()); }

            int[] dx = new int[4] { 0, 0, 1, -1 };
            int[] dy = new int[4] { 1, -1, 0, 0 };
            int RGBcount = 0;
            int RBcount = 0;

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    if (board[y][x] != '1' && board[y][x] != '2')
                    {
                        RGBcount++;
                        BFS(y, x, board[y][x]);
                    }
                }
            }

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    if (board[y][x] != '0')
                    {
                        RBcount++;
                        BFS(y, x, board[y][x]);
                    }
                }
            }

            sw.WriteLine($"{RGBcount} {RBcount}");

            void BFS(int Y, int X, char c)
            {
                char num = '0';

                if (c == 'R' || c == 'G') num = '1';
                if (c == 'B') num = '2';

                board[Y][X] = num;
                Queue<(int Y, int X)> q = new Queue<(int Y, int X)>();
                q.Enqueue((Y, X));

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var currentY = current.Y;
                    var currentX = current.X;

                    for (int d = 0; d < 4; d++)
                    {
                        var nextY = currentY + dy[d];
                        var nextX = currentX + dx[d];

                        if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) continue;
                        if (board[nextY][nextX] != c) continue;

                        board[nextY][nextX] = num;
                        q.Enqueue((nextY, nextX));
                    }
                }
            }

            sw.Close();
            sr.Close();
        }
    }
}
