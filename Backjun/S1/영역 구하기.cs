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
            int Y = inputs[0]; int X = inputs[1]; int T = inputs[2];
            int[,] board = new int[Y, X];

            for (int i = 0; i < T; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int x1 = inputs[0]; int y1 = inputs[1]; int x2 = inputs[2]; int y2 = inputs[3];


                for (int y = y1; y < y2; y++)
                {
                    for (int x = x1; x < x2; x++)
                    {
                        board[y, x] = 1;
                    }
                }
            }

            int[] dy = new int[4] { 0, 0, 1, -1 };
            int[] dx = new int[4] { 1, -1, 0, 0 };


            List<int> lst = new List<int>();
            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y, x] == 0) { BFS(y, x); }
                }
            }

            void BFS(int startY, int startX)
            {
                int count = 1;
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(new Pos(startY, startX));
                board[startY, startX] = 1;

                while (q.Count > 0)
                {
                    Pos currentPos = q.Dequeue();
                    int currentY = currentPos.Y;
                    int currentX = currentPos.X;

                    for (int d = 0; d < 4; d++)
                    {
                        int nextY = currentY + dy[d];
                        int nextX = currentX + dx[d];

                        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                        if (board[nextY, nextX] == 1) continue;

                        q.Enqueue(new Pos(nextY, nextX));
                        board[nextY, nextX] = 1;
                        count++;
                    }
                }

                lst.Add(count);
            }

            lst.Sort();

            sw.WriteLine(lst.Count);
            sw.WriteLine(string.Join(" ", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int X = 0;
        public int Y = 0;
        public Pos(int y, int x) { Y = y; X = x; }
    }
}
