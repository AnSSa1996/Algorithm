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
            int X = inputs[0]; int Y = inputs[1]; int H = inputs[2];

            int[,,] board = new int[H, Y, X];

            int[] dx = new int[6] { 1, -1, 0, 0, 0, 0 };
            int[] dy = new int[6] { 0, 0, 1, -1, 0, 0 };
            int[] dh = new int[6] { 0, 0, 0, 0, 1, -1 };

            int remainCount = 0;
            int result = -1;

            List<(int H, int Y, int X)> first = new List<(int H, int Y, int X)>();
            for (int h = 0; h < H; h++)
            {
                for (int y = 0; y < Y; y++)
                {
                    inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    for (int x = 0; x < X; x++)
                    {
                        if (inputs[x] == 0) remainCount++;
                        if (inputs[x] == 1) first.Add((h, y, x));
                        board[h, y, x] = inputs[x];
                    }
                }
            }

            BFS(first, 0);
            sw.WriteLine(result);

            void BFS(List<(int H, int Y, int X)> lst, int Depth)
            {
                if (remainCount == 0)
                {
                    result = Depth;
                    return;
                }
                Queue<(int H, int Y, int X)> q = new Queue<(int H, int Y, int X)>(lst);
                List<(int H, int Y, int X)> nextLst = new List<(int H, int Y, int X)>();

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var h = current.H;
                    var y = current.Y;
                    var x = current.X;

                    for (int d = 0; d < 6; d++)
                    {
                        var nextH = h + dh[d];
                        var nextY = y + dy[d];
                        var nextX = x + dx[d];

                        if (nextH < 0 || nextH >= H || nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                        if (board[nextH, nextY, nextX] != 0) continue;

                        board[nextH, nextY, nextX] = 1;
                        nextLst.Add((nextH, nextY, nextX));
                        remainCount--;
                    }
                }

                if (lst.Count == 0) return;
                BFS(nextLst, Depth + 1);
            }

            sw.Close();
            sr.Close();
        }
    }
}
