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

            for (int i = 0; i < N; i++) { List<int> lst = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList(); board.Add(lst); }

            int min = int.MaxValue;

            for (int i = 0; i < N; i++)
            { DFS(i, i, 1 << i, 0); }

            sw.WriteLine(min);

            void DFS(int origin, int start, int visited, int cost)
            {
                if (visited == (1 << N) - 1 && board[start][origin] != 0)
                { if (min > cost + board[start][origin]) min = cost + board[start][origin]; return; }

                for (int next = 0; next < N; next++)
                {
                    if (((1 << next) & visited) == 0 && min > (cost + board[start][next]) && board[start][next] != 0)
                    { DFS(origin, next, visited | (1 << next), cost + board[start][next]); }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}