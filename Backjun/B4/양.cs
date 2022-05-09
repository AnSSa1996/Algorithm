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
            int H = inputs[0]; int W = inputs[1];

            int[] dx = new int[4] { 1, 0, -1, 0 };
            int[] dy = new int[4] { 0, -1, 0, 1 };

            List<List<char>> board = new List<List<char>>();

            int[] answer = new int[2];

            for (int i = 0; i < H; i++)
            {
                List<char> lst = sr.ReadLine().ToList();
                board.Add(lst);
            }

            for (int StartY = 0; StartY < H; StartY++)
            {
                for (int StartX = 0; StartX < W; StartX++)
                {
                    if (board[StartY][StartX] != '#') BFS(new Pos(StartY, StartX));
                }
            }

            void BFS(Pos pos)
            {
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(pos);

                int sheep = 0;
                int wolf = 0;

                if (board[pos.Y][pos.X] != '#')
                {
                    if (board[pos.Y][pos.X] == 'o') sheep++;
                    else if (board[pos.Y][pos.X] == 'v') wolf++;
                    board[pos.Y][pos.X] = '#';
                }

                while (q.Count > 0)
                {
                    Pos currentPos = q.Dequeue();
                    int y = currentPos.Y;
                    int x = currentPos.X;

                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = y + dy[i];
                        int nextX = x + dx[i];
                        if (nextY < 0 || nextY >= H || nextX < 0 || nextX >= W) continue;
                        if (board[nextY][nextX] != '#')
                        {
                            if (board[nextY][nextX] == 'o') sheep++;
                            else if (board[nextY][nextX] == 'v') wolf++;
                            board[nextY][nextX] = '#';
                            q.Enqueue(new Pos(nextY, nextX));
                        }
                    }
                }

                if (wolf >= sheep) answer[1] += wolf;
                else answer[0] += sheep;
            }

            sw.WriteLine($"{answer[0]} {answer[1]}");

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
