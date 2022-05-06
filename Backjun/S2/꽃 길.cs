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

            int N = int.Parse(sr.ReadLine());
            List<List<int>> fields = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                fields.Add(lst);
            }
            bool[,] board = new bool[N, N];

            int[] dx = new int[5] { -1, 1, 0, 0, 0 };
            int[] dy = new int[5] { 0, 0, -1, 1, 0 };

            int minTotal = int.MaxValue;

            for (int y = 0; y < N; y++)
            {
                for (int x = 0; x < N; x++)
                {
                    DFS(y, x, 3, 0);
                }
            }


            void DFS(int startY, int startX, int count, int total)
            {
                if (count == 0) { minTotal = Math.Min(minTotal, total); return; }
                for (int y = startY; y < N; y++)
                {
                    for (int x = startX; x < N; x++)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int nextY = y + dy[i];
                            int nextX = x + dx[i];
                            if (nextY < 0 || nextY >= N || nextX < 0 || nextX >= N) goto end;
                            if (board[nextY, nextX] == true) goto end;
                        }

                        for (int i = 0; i < 5; i++)
                        {
                            int nextY = y + dy[i];
                            int nextX = x + dx[i];
                            board[nextY, nextX] = true;
                            total += fields[nextY][nextX];
                        }
                        DFS(0, 0, count - 1, total);
                        for (int i = 0; i < 5; i++)
                        {
                            int nextY = y + dy[i];
                            int nextX = x + dx[i];
                            board[nextY, nextX] = false;
                            total -= fields[nextY][nextX];
                        }

                    end:;
                    }
                }
            }

            sw.WriteLine(minTotal);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}