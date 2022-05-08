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
            int Y = inputs[0]; int X = inputs[1];
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < Y; i++)
            {
                List<char> lst = sr.ReadLine().ToList();
                board.Add(lst);
            }

            int totalWolf = 0;
            int totalSheep = 0;

            int[] dx = new int[4] { -1, 1, 0, 0 };
            int[] dy = new int[4] { 0, 0, -1, 1 };

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y][x] != '#') BFS(y, x);
                }
            }

            sw.WriteLine($"{totalSheep} {totalWolf}");

            void BFS(int startY, int startX)
            {
                int wolf = 0; int sheep = 0;
                if (board[startY][startX] == 'v') wolf = 1;
                else if (board[startY][startX] == 'k') sheep = 1;
                board[startY][startX] = '#';
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(new Pos(startY, startX));

                while (q.Count > 0)
                {
                    Pos currentPos = q.Dequeue();
                    int currentY = currentPos.Y;
                    int currentX = currentPos.X;

                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = currentY + dy[i];
                        int nextX = currentX + dx[i];
                        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                        if (board[nextY][nextX] == '#') continue;
                        else if (board[nextY][nextX] == 'v') { wolf += 1; }
                        else if (board[nextY][nextX] == 'k') { sheep += 1; }

                        board[nextY][nextX] = '#';
                        q.Enqueue(new Pos(nextY, nextX));
                    }
                }

                if (wolf >= sheep) totalWolf += wolf;
                else totalSheep += sheep;
            }


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