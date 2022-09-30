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
            int N = inputs[0]; int L = inputs[1]; int R = inputs[2];
            int[,] board = new int[N, N];

            int[] dx = new int[4] { 0, 0, -1, 1 };
            int[] dy = new int[4] { -1, 1, 0, 0 };

            for (int y = 0; y < N; y++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < N; x++)
                {
                    board[y, x] = inputs[x];
                }
            }

            int count = 0;

            while (true)
            {
                int check = 0;
                bool[,] visited = new bool[N, N];
                for (int y = 0; y < N; y++)
                {
                    for (int x = 0; x < N; x++)
                    {
                        if (visited[y, x]) continue;
                        check += BFS(y, x, ref visited);
                    }
                }
                if (check == 0) break;
                count++;
            }

            sw.WriteLine(count);

            int BFS(int y, int x, ref bool[,] visited)
            {
                Queue<(int Y, int X)> q = new Queue<(int Y, int X)>();
                List<(int Y, int X)> lst = new List<(int Y, int X)>();
                lst.Add((y, x));
                q.Enqueue((y, x));
                visited[y, x] = true;
                int sum = board[y, x];
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
                        if (visited[nextY, nextX]) continue;
                        var diff = Math.Abs(board[currentY, currentX] - board[nextY, nextX]);
                        if (diff < L || diff > R) continue;
                        q.Enqueue((nextY, nextX));
                        lst.Add((nextY, nextX));
                        visited[nextY, nextX] = true;
                        sum += board[nextY, nextX];
                    }
                }

                if (lst.Count() >= 2)
                {
                    int num = sum / lst.Count();
                    foreach (var pos in lst)
                    {
                        board[pos.Y, pos.X] = num;
                    }

                    return 1;
                }

                return 0;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}