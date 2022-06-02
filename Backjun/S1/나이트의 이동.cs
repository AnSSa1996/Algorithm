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

            int T = int.Parse(sr.ReadLine());
            int[] dy = new int[8] { 1, 1, 2, 2, -1, -1, -2, -2 };
            int[] dx = new int[8] { 2, -2, 1, -1, 2, -2, 1, -1 };

            for (int i = 0; i < T; i++)
            {
                int size = int.Parse(sr.ReadLine());
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int cY = inputs[0]; int cX = inputs[1];
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int tY = inputs[0]; int tX = inputs[1];

                bool[,] check = new bool[size, size];
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(new Pos(cY, cX, 0));
                check[cY, cX] = true;

                int count = 0;

                while (q.Count > 0)
                {
                    Pos currentPos = q.Dequeue();
                    int currentY = currentPos.Y;
                    int currentX = currentPos.X;
                    int currentCount = currentPos.Count;
                    if (currentY == tY && currentX == tX)
                    {
                        count = currentCount;
                        break;
                    }

                    for (int d = 0; d < 8; d++)
                    {
                        int nextY = currentY + dy[d];
                        int nextX = currentX + dx[d];

                        if (nextY < 0 || nextY >= size || nextX < 0 || nextX >= size) continue;
                        if (check[nextY, nextX]) continue;

                        check[nextY, nextX] = true;
                        q.Enqueue(new Pos(nextY, nextX, currentCount + 1));
                    }
                }

                sw.WriteLine(count);
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
        public int Count;
        public Pos(int y, int x, int count) { Y = y; X = x; Count = count; }
    }
}
