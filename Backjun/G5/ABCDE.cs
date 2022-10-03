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
            int N = inputs[0]; int L = inputs[1];
            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i < N; i++) lines.Add(new List<int>());

            for (int i = 0; i < L; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lines[inputs[0]].Add(inputs[1]);
                lines[inputs[1]].Add(inputs[0]);
            }


            bool check = false;
            bool[] visited = new bool[N + 1];

            for (int i = 0; i < N; i++)
            {
                if (check) break;
                visited[i] = true;
                DFS(i, 0);
                visited[i] = false;
            }
            void DFS(int start, int depth)
            {
                if (depth == 4)
                {
                    check = true;
                    return;
                }

                foreach (var next in lines[start])
                {
                    if (visited[next]) continue;
                    visited[next] = true;
                    DFS(next, depth + 1);
                    visited[next] = false;
                }
            }

            if (check) { sw.WriteLine(1);}
            else sw.WriteLine(0);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}