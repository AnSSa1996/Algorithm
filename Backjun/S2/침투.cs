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
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < Y; i++)
            {
                List<int> lst = sr.ReadLine().Select(x => x - '0').ToList();
                board.Add(lst);
            }


            Queue<Pos> q = new Queue<Pos>();
            for (int x = 0; x < X; x++)
            {
                if (board[0][x] == 0) { q.Enqueue(new Pos(0, x)); board[0][x] = 1; }
            }

            bool check = false;
            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };
            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int currentY = currentPos.Y;
                int currentX = currentPos.X;
                if (currentY >= (Y - 1)) { check = true; break; }

                for (int i = 0; i < 4; i++)
                {
                    int nextY = currentY + dy[i];
                    int nextX = currentX + dx[i];
                    if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                    if (board[nextY][nextX] == 1) continue;

                    board[nextY][nextX] = 1;
                    q.Enqueue(new Pos(nextY, nextX));
                }
            }

            if (check) sw.WriteLine("YES");
            else sw.WriteLine("NO");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int X;
        public int Y;
        public Pos(int y, int x) { Y = y; X = x; }
    }
}