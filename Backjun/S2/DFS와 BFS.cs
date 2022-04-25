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
            int N = inputs[0]; int M = inputs[1]; int V = inputs[2];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i < N; i++) board.Add(new List<int>());
            for (int i = 0; i < M; i++)
            {
                int[] lines = Array.ConvertAll(sr.ReadLine().Split(), int.Parse); ;
                board[lines[0] - 1].Add(lines[1] - 1);
                board[lines[1] - 1].Add(lines[0] - 1);
            }
            for (int i = 0; i < N; i++) board[i].Sort();


            bool[] checkDFS = new bool[N];
            bool[] checkBFS = new bool[N];
            StringBuilder dfsSb = new StringBuilder();
            StringBuilder bfsSb = new StringBuilder();

            dfsSb.Append($"{V} ");
            checkDFS[V - 1] = true;
            DFS(V - 1);
            dfsSb.Remove(dfsSb.Length - 1, 1);


            BFS(V);
            sw.WriteLine(dfsSb);
            sw.WriteLine(bfsSb);

            void DFS(int start)
            {
                foreach (var next in board[start])
                {
                    if (checkDFS[next] == false)
                    {
                        checkDFS[next] = true;
                        dfsSb.Append($"{next + 1} ");
                        DFS(next);
                    }
                }
            }


            void BFS(int start)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(start - 1);
                checkBFS[start - 1] = true;
                bfsSb.Append($"{start} ");

                while (q.Count > 0)
                {
                    int current = q.Dequeue();
                    foreach (var next in board[current])
                    {
                        if (checkBFS[next] == false)
                        {
                            checkBFS[next] = true;
                            bfsSb.Append($"{next + 1} ");
                            q.Enqueue(next);
                        }
                    }
                }

                bfsSb.Remove(bfsSb.Length - 1, 1);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}