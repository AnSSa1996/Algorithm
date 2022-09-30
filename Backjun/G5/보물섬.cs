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
            int H = inputs[0]; int W = inputs[1];

            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < H; i++)
            {
                board.Add(sr.ReadLine().ToList());
            }

            int result = 0;

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    if (board[y][x] == 'W') continue;
                    int v = BFS(y, x);
                    if (v > result) result = v;
                }
            }

            sw.WriteLine(result);

            int BFS(int Y, int X)
            {
                Queue<(int y, int x, int distance)> q = new Queue<(int y, int x, int distance)>();
                bool[,] visited = new bool[H, W];
                q.Enqueue((Y, X, 0));
                visited[Y, X] = true;
                int[] dx = new int[4] { 1, -1, 0, 0 };
                int[] dy = new int[4] { 0, 0, 1, -1 };

                int max = 0;

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var y = current.y;
                    var x = current.x;
                    var distance = current.distance;
                    if (max < distance) max = distance;

                    for (int d = 0; d < 4; d++)
                    {
                        var nextY = y + dy[d];
                        var nextX = x + dx[d];

                        if (nextX < 0 || nextX >= W || nextY < 0 || nextY >= H) continue;
                        if (board[nextY][nextX] == 'W') continue;
                        if (visited[nextY, nextX]) continue;

                        visited[nextY, nextX] = true;
                        q.Enqueue((nextY, nextX, distance + 1));
                    }
                }

                return max;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}