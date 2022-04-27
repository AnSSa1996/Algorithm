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

            int N = int.Parse(sr.ReadLine()); int T = int.Parse(sr.ReadLine());
            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i <= N; i++) board.Add(new List<int>());
            for (int i = 0; i < T; i++)
            {
                int[] L = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board[L[1]].Add(L[0]);
                board[L[0]].Add(L[1]);
            }

            bool[] visited = new bool[N + 1];
            visited[1] = true;

            int cnt = 0;
            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(new Pos(1, 0));

            while (q.Count > 0)
            {
                Pos currentPos = q.Dequeue();
                int current = currentPos.Current;
                int depth = currentPos.Depth;

                foreach (var next in board[current])
                {
                    if (visited[next] == false && depth <= 1)
                    {
                        visited[next] = true;
                        q.Enqueue(new Pos(next, depth + 1));
                        cnt++;
                    }
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }

    public class Pos
    {
        public int Current;
        public int Depth;
        public Pos(int current, int depth) { Current = current; Depth = depth; }
    }
}