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

            int[,] board = new int[N, N];

            for (int y = 0; y < N; y++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int x = 0; x < N; x++)
                {
                    board[y, x] = inputs[x];
                }
            }

            int[] dx = new int[3] { 1, 0, 1 };
            int[] dy = new int[3] { 0, 1, 1 };
            int result = 0;

            DFS(0, 1, 0);
            sw.WriteLine(result);

            void DFS(int y, int x, int dir)
            {

                if (y == N - 1 && x == N - 1)
                {
                    result++;
                }

                // 가로
                int nextY = 0;
                int nextX = 0;

                if (dir == 0)
                {
                    nextY = y; nextX = x + 1;
                    if (Check(nextY, nextX, 0)) DFS(y, x + 1, 0);
                    else return;
                    nextY = y + 1; nextX = x + 1;
                    if (Check(nextY, nextX, 2)) DFS(y + 1, x + 1, 2);
                }

                if (dir == 1)
                {
                    nextY = y + 1; nextX = x;
                    if (Check(nextY, nextX, 1)) DFS(y + 1, x, 1);
                    else return;
                    nextY = y + 1; nextX = x + 1;
                    if (Check(nextY, nextX, 2)) DFS(y + 1, x + 1, 2);
                }

                if (dir == 2)
                {
                    nextY = y; nextX = x + 1;
                    if (Check(nextY, nextX, 0)) DFS(y, x + 1, 0);
                    nextY = y + 1; nextX = x;
                    if (Check(nextY, nextX, 1)) DFS(y + 1, x, 1);
                    nextY = y + 1; nextX = x + 1;
                    if (Check(nextY, nextX, 2)) DFS(y + 1, x + 1, 2);
                }

                return;
            }

            bool Check(int y, int x, int dir)
            {
                if (y < 0 || y >= N || x < 0 || x >= N) return false;
                if (dir != 2 && board[y, x] == 0) return true;
                if (dir == 2 && board[y, x] == 0 && board[y - 1, x] == 0 && board[y, x - 1] == 0) return true;
                return false;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}