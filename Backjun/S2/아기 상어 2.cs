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
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < H; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }

            Queue<Pos> q = new Queue<Pos>();
            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    if (board[y][x] == 1) q.Enqueue(new Pos(y, x, 0));
                }
            }


            int[] dx = new int[8] { -1, 1, 0, 0, 1, 1, -1, -1 };
            int[] dy = new int[8] { 0, 0, -1, 1, 1, -1, 1, -1 };
            int maxDepth = 0;
            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int currentY = currentPos.Y;
                int currentX = currentPos.X;
                int currentDepth = currentPos.Depth;
                if (maxDepth < currentDepth) maxDepth = currentDepth;
                for (int i = 0; i < 8; i++)
                {
                    int nextY = currentY + dy[i];
                    int nextX = currentX + dx[i];
                    if (nextY < 0 || nextY >= H || nextX < 0 || nextX >= W) continue;
                    if (board[nextY][nextX] == 1) continue;
                    board[nextY][nextX] = 1;
                    q.Enqueue(new Pos(nextY, nextX, currentDepth + 1));
                }
            }

            sw.WriteLine(maxDepth);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int Y;
        public int X;
        public int Depth;
        public Pos(int y, int x, int depth) { Y = y; X = x; Depth = depth; }
    }
}