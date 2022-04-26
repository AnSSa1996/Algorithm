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
            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i <= N; i++) { lines.Add(new List<int>()); }
            for (int i = 0; i < (N - 1); i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lines[inputs[0]].Add(inputs[1]);
                lines[inputs[1]].Add(inputs[0]);
            }

            int[] parent = new int[N + 1];
            bool[] visited = new bool[N + 1];

            for (int i = 1; i <= N; i++)
            {
                if (visited[i] == false)
                {
                    parent[i] = 1;
                    visited[i] = true;
                    DFS(i);
                }
            }

            for (int i = 2; i <= N; i++) sw.WriteLine(parent[i]);

            void DFS(int start)
            {
                foreach (var next in lines[start])
                {
                    if (visited[next] == true) continue;
                    parent[next] = start;
                    visited[next] = true;
                    DFS(next);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}