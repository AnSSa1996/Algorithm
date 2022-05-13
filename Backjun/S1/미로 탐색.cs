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
            int Y = inputs[0]; int X = inputs[1];
            List<List<char>> board = new List<List<char>>();
            for (int i = 0; i < Y; i++) board.Add(sr.ReadLine().ToList());

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(0, 0, 0));
            board[0][0] = '0';

            int result = 0;
            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int curY = currentPos.Y;
                int curX = currentPos.X;
                int curDepth = currentPos.Depth;
                if (curY == Y - 1 && curX == X - 1)
                {
                    result = curDepth; break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int nextY = curY + dy[i];
                    int nextX = curX + dx[i];
                    if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                    if (board[nextY][nextX] == '0') continue;

                    board[nextY][nextX] = '0';
                    q.Enqueue(new Pos(nextY, nextX, curDepth + 1));
                }
            }

            sw.WriteLine(result + 1);

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
