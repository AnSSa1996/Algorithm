using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int startX = inputs[0]; int startY = inputs[1];
            int targetX = inputs[2]; int targetY = inputs[3];

            int[] dx = new int[6] { -2, -2, 0, 0, 2, 2 };
            int[] dy = new int[6] { -1, 1, -2, 2, -1, 1 };

            bool[,] board = new bool[N, N];

            Queue<(int X, int Y, int Count)> q = new Queue<(int X, int Y, int Count)>();
            q.Enqueue((startX, startY, 0));
            board[startX, startY] = true;

            int answer = -1;
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                var X = current.X;
                var Y = current.Y;
                var count = current.Count;

                if (X == targetX && Y == targetY)
                {
                    answer = count; break;
                }

                for (int dir = 0; dir < 6; dir++)
                {
                    var nextX = X + dx[dir];
                    var nextY = Y + dy[dir];

                    if (nextX < 0 || nextX >= N || nextY < 0 || nextY >= N) continue;
                    if (board[nextX, nextY]) continue;
                    board[nextX, nextY] = true;
                    q.Enqueue((nextX, nextY, count + 1));
                }
            }

            sw.WriteLine(answer);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}