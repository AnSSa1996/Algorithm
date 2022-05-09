using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
            int N = inputs[0]; int K = inputs[1];

            int[] exercises = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            bool[] visited = new bool[N];

            int cnt = 0;
            DFS(500, 0);
            sw.WriteLine(cnt);

            void DFS(int total, int n)
            {
                if (n == N) { cnt++; return; }
                for (int i = 0; i < N; i++)
                {
                    if (visited[i] == false)
                    {
                        if (total + exercises[i] - K < 500) continue;
                        total += exercises[i] - K;
                        visited[i] = true;
                        DFS(total, n + 1);
                        total -= exercises[i] - K;
                        visited[i] = false;
                    }
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }

    }
}
