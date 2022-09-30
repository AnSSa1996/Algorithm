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

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int W = inputs[0]; int H = inputs[1];
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < H; i++) { board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList()); }

            int[] dx = new int[4] { -1, 1, 0, 0 };
            int[] dy = new int[4] { 0, 0, -1, 1 };

            int checkCount = 0;
            int result = -1;

            List<(int Y, int X)> firstQ = new List<(int Y, int X)>();

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    if (board[y][x] == 1) firstQ.Add((y, x));
                    if (board[y][x] == 0) checkCount++;
                }
            }

            void SanghunSolution(List<(int Y, int X)> lst, int Count)
            {
                Queue<(int Y, int X)> q = new Queue<(int Y, int X)>(lst);
                List<(int Y, int X)> nextLst = new List<(int Y, int X)>();

                while (q.Count > 0)
                {
                    if (checkCount == 0)
                    {
                        result = Count;
                        break;
                    }

                    var current = q.Dequeue();
                    var Y = current.Y;
                    var X = current.X;

                    for (int d = 0; d < 4; d++)
                    {
                        var nextX = X + dx[d];
                        var nextY = Y + dy[d];
                        if (nextX >= W || nextX < 0 || nextY >= H || nextY < 0) continue;
                        if (board[nextY][nextX] != 0) continue;

                        board[nextY][nextX] = 1;
                        nextLst.Add((nextY, nextX));
                        checkCount--;
                    }
                }

                if (nextLst.Count <= 0) return;
                SanghunSolution(nextLst, Count + 1);
            }

            SanghunSolution(firstQ, 0);
            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
