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
            int N = inputs[0]; int M = inputs[1]; int K = inputs[2]; int X = inputs[3];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i <= N; i++) board.Add(new List<int>());
            for (int i = 0; i < M; i++)
            {
                int[] L = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board[L[0]].Add(L[1]);
            }

            List<int> answerLst = new List<int>();

            bool[] visited = new bool[N + 1];
            Queue<Pos> q = new Queue<Pos>();
            visited[X] = true;
            q.Enqueue(new Pos(X, 0));

            while (q.Count > 0)
            {
                Pos cPos = q.Dequeue();
                int current = cPos.Current;
                int depth = cPos.Depth;

                if (depth == K) { answerLst.Add(current); continue; }

                foreach (var next in board[current])
                {
                    if (visited[next] == false && depth < K)
                    {
                        visited[next] = true;
                        q.Enqueue(new Pos(next, depth + 1));
                    }
                }
            }

            answerLst.Sort();
            if (answerLst.Count > 0) sw.WriteLine(string.Join("\n", answerLst));
            else sw.WriteLine(-1);

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