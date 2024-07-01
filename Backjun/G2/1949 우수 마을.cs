using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Backj
{
    internal class Program
    {
        private static int N;
        private static int[] towns;
        private static List<int>[] graph;
        private static int[,] dp;

        private static void Main(string[] args)
        {
            var sr = new StreamReader(Console.OpenStandardInput());
            var sw = new StreamWriter(Console.OpenStandardOutput());

            N = int.Parse(sr.ReadLine());
            towns = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph = new List<int>[N + 1];
            dp = new int[N + 1, 2];

            for (var i = 0; i <= N; i++)
            {
                graph[i] = new List<int>();
            }

            for (var i = 0; i < N - 1; i++)
            {
                var input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                graph[input[0]].Add(input[1]);
                graph[input[1]].Add(input[0]);
            }

            DFS(1);
            sw.WriteLine(Math.Max(dp[1, 0], dp[1, 1]));

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void DFS(int current)
        {
            dp[current, 0] = 0;
            dp[current, 1] = towns[current - 1];
            foreach (var next in graph[current])
            {
                if (dp[next, 0] != 0) continue;
                if (dp[next, 1] != 0) continue;
                DFS(next);
                dp[current, 0] += Math.Max(dp[next, 0], dp[next, 1]);
                dp[current, 1] += dp[next, 0];
            }
        }
    }
}