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
            for (int i = 0; i <= N; i++) board.Add(new List<int>());
            for (int i = 0; i < T; i++)
            {
                int[] lines = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board[lines[0]].Add(lines[1]);
                board[lines[1]].Add(lines[0]);
            }


            bool[] vistied = new bool[N + 1];
            int cnt = 0;
            for (int i = 1; i <= N; i++)
            {
                if (vistied[i] == false)
                {
                    cnt++;
                    BFS(i);
                    vistied[i] = true;
                }
            }

            sw.WriteLine(cnt);

            void BFS(int start)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(start);

                while (q.Count() > 0)
                {
                    int curent = q.Dequeue();
                    foreach (var next in board[curent])
                    {
                        if (vistied[next] == false)
                        {
                            q.Enqueue(next);
                            vistied[next] = true;
                        }
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}