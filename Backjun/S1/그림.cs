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

            for (int i = 0; i < Y; i++) { board.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList()); }

            int count = 0;
            int max = 0;

            int[] dY = new int[4] { 0, 0, 1, -1 };
            int[] dX = new int[4] { 1, -1, 0, 0 };

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    if (board[y][x] == 1)
                    {
                        BFS(y, x);
                        count++;
                    }
                }
            }

            sw.WriteLine(count);
            sw.WriteLine(max);


            void BFS(int startY, int startX)
            {
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(new Pos(startY, startX));
                board[startY][startX] = 0;

                int length = 1;
                while (q.Count > 0)
                {
                    Pos current = q.Dequeue();
                    int y = current.Y;
                    int x = current.X;

                    for (int i = 0; i < 4; i++)
                    {
                        int nextY = y + dY[i];
                        int nextX = x + dX[i];

                        if (nextY < 0 || nextY >= Y || nextX < 0 || nextX >= X) continue;
                        if (board[nextY][nextX] == 0) continue;
                        length++; board[nextY][nextX] = 0;
                        q.Enqueue(new Pos(nextY, nextX));
                    }
                }

                if (max < length) max = length;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
    public class Pos
    {
        public int Y = 0;
        public int X = 0;
        public Pos(int y, int x) { Y = y; X = x; }
    }
}