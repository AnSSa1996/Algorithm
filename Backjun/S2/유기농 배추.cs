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

            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, -1, 0, 1 };

            int T = int.Parse(sr.ReadLine());


            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int width = inputs[0]; int height = inputs[1];
                int K = inputs[2];

                int[,] board = new int[width, height];

                for (int j = 0; j < K; j++)
                {
                    int[] pos = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                    board[pos[0], pos[1]] = 1;
                }

                int cnt = 0;
                for (int a = 0; a < width; a++)
                {
                    for (int b = 0; b < height; b++)
                    {
                        if (board[a, b] == 1)
                        {
                            board[a, b] = 0;
                            Pos current = new Pos(a, b);
                            BFS(current);
                            cnt++;
                        }
                    }
                }

                sw.WriteLine(cnt);

                void BFS(Pos start)
                {
                    Queue<Pos> q = new Queue<Pos>();
                    q.Enqueue(start);

                    while (q.Count > 0)
                    {
                        Pos current = q.Dequeue();
                        int currentX = current.X;
                        int currentY = current.Y;
                        for (int d = 0; d < 4; d++)
                        {
                            int nextX = currentX + dx[d];
                            int nextY = currentY + dy[d];

                            if (nextX < 0 || nextX >= width || nextY < 0 || nextY >= height) continue;
                            if (board[nextX, nextY] == 1) { q.Enqueue(new Pos(nextX, nextY)); board[nextX, nextY] = 0; }
                        }
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int X;
        public int Y;
        public Pos(int x, int y) { X = x; Y = y; }
    }
}