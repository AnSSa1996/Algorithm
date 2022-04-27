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
            int[] questions = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int left = questions[0]; int right = questions[1];

            int lineCount = int.Parse(sr.ReadLine());
            List<List<int>> lines = new List<List<int>>();
            for (int i = 0; i <= N; i++) lines.Add(new List<int>());
            for (int i = 0; i < lineCount; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lines[line[0]].Add(line[1]);
                lines[line[1]].Add(line[0]);
            }

            bool[] vistied = new bool[N + 1];

            int cnt = -1;
            DFS(left, right, 0);
            sw.WriteLine(cnt);

            void DFS(int start, int answer, int depth)
            {
                if (start == answer) { cnt = depth; return; }
                foreach (var next in lines[start])
                {
                    if (vistied[next] == true) continue;
                    vistied[next] = true;
                    DFS(next, answer, depth + 1);
                }
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}