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

            int[] dx = new int[8] { 1, -1, 0, 0, 1, 1, -1, -1 };
            int[] dy = new int[8] { 0, 0, 1, -1, 1, -1, -1, 1 };
            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                if (inputs[0] == 0) break;
                int X = inputs[0]; int Y = inputs[1];

                List<List<int>> board = new List<List<int>>();
                for (int i = 0; i < Y; i++)
                {
                    List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                    board.Add(lst);
                }

                int cnt = 0;
                for (int y = 0; y < Y; y++)
                {
                    for (int x = 0; x < X; x++)
                    {
                        if (board[y][x] == 1)
                        {
                            BFS(new Pos(x, y));
                            cnt++;
                        }
                    }
                }

                sw.WriteLine(cnt);

                void BFS(Pos pos)
                {
                    Queue<Pos> q = new Queue<Pos>();
                    q.Enqueue(pos);
                    board[pos.Y][pos.X] = 0;
                    while (q.Count > 0)
                    {
                        Pos currentPos = q.Dequeue();

                        for (int d = 0; d < 8; d++)
                        {
                            int nextY = currentPos.Y + dy[d];
                            int nextX = currentPos.X + dx[d];

                            if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                            if (board[nextY][nextX] == 1)
                            {
                                board[nextY][nextX] = 0;
                                q.Enqueue(new Pos(nextX, nextY));
                            }
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