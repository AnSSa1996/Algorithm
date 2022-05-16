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
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < N; i++) board.Add(sr.ReadLine().ToList());
            List<int> results = new List<int>();

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    if (board[y][x] == '1') BFS(y, x);
                }
            }

            void BFS(int startY, int startX)
            {
                Queue<Pos> q = new Queue<Pos>();

                int total = 1;

                board[startY][startX] = '0';
                q.Enqueue(new Pos(startY, startX));

                while (q.Count > 0)
                {
                    Pos curPos = q.Dequeue();
                    int curY = curPos.Y;
                    int curX = curPos.X;

                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = curY + dy[i];
                        int nextX = curX + dx[i];

                        if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N) continue;
                        if (board[nextY][nextX] == '0') continue;

                        board[nextY][nextX] = '0';
                        total++;
                        q.Enqueue(new Pos(nextY, nextX));
                    }
                }
                results.Add(total);
            }

            int count = results.Count();
            results.Sort();

            sw.WriteLine(count);
            for (int i = 0; i < count; i++) sw.WriteLine(results[i]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int Y;
        public int X;
        public Pos(int y, int x) { Y = y; X = x; }
    }
}
