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
            bool[,] board = new bool[Y + 1, X + 1];
            for (int i = 0; i < T; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int s = inputs[0]; int e = inputs[1];
                board[s, e] = true;
            }

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };

            int max = 0;


            for (int sY = 1; sY <= Y; sY++)
            {
                for (int sX = 1; sX <= X; sX++)
                {
                    if (board[sY, sX]) { max = Math.Max(max, BFS(sY, sX)); }
                }
            }


            int BFS(int startY, int startX)
            {
                int count = 1;
                Queue<Pos> q = new Queue<Pos>();
                q.Enqueue(new Pos(startY, startX));
                board[startY, startX] = false;
                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var y = current.Y;
                    var x = current.X;

                    for (int i = 0; i < 4; i++)
                    {
                        var nextY = y + dy[i];
                        var nextX = x + dx[i];

                        if (nextY < 1 || nextY > Y || nextX < 1 || nextX > X) continue;
                        if (board[nextY, nextX] == false) continue;

                        board[nextY, nextX] = false;
                        q.Enqueue(new Pos(nextY, nextX));
                        count++;
                    }
                }

                return count;
            }


            sw.WriteLine(max);

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