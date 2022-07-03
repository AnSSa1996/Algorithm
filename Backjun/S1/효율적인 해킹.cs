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
            int N = inputs[0]; int T = inputs[1];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) board.Add(new List<int>());

            for (int i = 0; i < T; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int X = inputs[0] - 1; int Y = inputs[1] - 1;
                board[Y].Add(X);
            }

            List<Tuple<int, int>> result = new List<Tuple<int, int>>();
            for (int i = 0; i < N; i++)
            {
                int count = BFS(i);
                int index = i + 1;
                result.Add(new Tuple<int, int>(index, count));
            }

            var max = result.Max(x => x.Item2);
            var results = result.Where(x => x.Item2 == max).Select(x => x.Item1);
            sw.WriteLine(string.Join(" ", results));

            int BFS(int start)
            {
                bool[] visted = new bool[N];
                visted[start] = true;

                Queue<int> q = new Queue<int>();
                q.Enqueue(start);

                int count = 1;

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    foreach (var next in board[current])
                    {
                        if (visted[next] == true) continue;
                        q.Enqueue(next); count++; visted[next] = true;
                    }
                }

                return count;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}