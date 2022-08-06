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
            int W = inputs[0]; int H = inputs[1];
            List<List<char>> board = new List<List<char>>();

            for (int i = 0; i < H; i++)
            {
                board.Add(sr.ReadLine().ToList());
            }

            int myScore = 0;
            int enemyScore = 0;


            int[] dy = new int[4] { 1, -1, 0, 0 };
            int[] dx = new int[4] { 0, 0, 1, -1 };


            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    if (board[y][x] == 'W')
                    {
                        myScore += BFS('W', y, x);
                    }
                    else if (board[y][x] == 'B')
                    {
                        enemyScore += BFS('B', y, x);
                    }
                }
            }

            sw.WriteLine(myScore);
            sw.WriteLine(enemyScore);

            int BFS(char c, int y, int x)
            {
                Queue<(int Y, int X)> q = new Queue<(int Y, int X)>();
                q.Enqueue((y, x));
                board[y][x] = '0';

                int count = 1;

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    var Y = current.Y;
                    var X = current.X;

                    for (int d = 0; d < 4; d++)
                    {
                        var nextY = Y + dy[d];
                        var nextX = X + dx[d];

                        if (nextY < 0 || nextY >= H || nextX < 0 || nextX >= W) continue;
                        if (board[nextY][nextX] != c) continue;

                        board[nextY][nextX] = '0';
                        count++;
                        q.Enqueue((nextY, nextX));
                    }
                }

                return count * count;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}