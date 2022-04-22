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
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++)
            {
                List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                board.Add(lst);
            }

            int[] colors = new int[2];
            DFS(0, 0, N);

            sw.WriteLine(colors[0]);
            sw.WriteLine(colors[1]);

            void DFS(int Y, int X, int num)
            {
                int color = board[Y][X];
                if (num == 1) { colors[color]++; return; }


                for (int y = Y; y < Y + num; y++)
                {
                    for (int x = X; x < X + num; x++)
                    {
                        if (board[y][x] != color) { goto end; }
                    }
                }
                colors[color]++; return;
            end:
                int nextNum = num / 2;
                DFS(Y, X, nextNum);
                DFS(Y, X + nextNum, nextNum);
                DFS(Y + nextNum, X, nextNum);
                DFS(Y + nextNum, X + nextNum, nextNum);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}