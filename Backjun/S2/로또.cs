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

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int N = inputs[0];
                if (N == 0) break;
                bool[] visited = new bool[N];
                DFS(0, N, new int[6], sb, visited, inputs, 0);
                sb.AppendLine();
            }

            sb.Remove(sb.Length - 1, 1);
            sw.Write(sb);

            sw.Flush();
            sw.Close();
            sr.Close();

        }

        public static void DFS(int K, int N, int[] nums, StringBuilder sb, bool[] visited, int[] inputs, int currentN)
        {
            if (K == 6) { sb.AppendLine(string.Join(" ", nums)); return; }
            for (int i = K; i < N; i++)
            {
                if (visited[i] == false && currentN <= i)
                {
                    visited[i] = true;
                    nums[K] = inputs[i + 1];
                    DFS(K + 1, N, nums, sb, visited, inputs, i);
                    visited[i] = false;
                }
            }
        }
    }
}