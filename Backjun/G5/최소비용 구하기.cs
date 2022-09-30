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
            int L = int.Parse(sr.ReadLine());
            int INF = 100000000;

            int[,] board = new int[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    board[i, j] = 100000000;
                }
            }

            for (int i = 0; i < L; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int s = inputs[0]; int e = inputs[1]; int v = inputs[2];
                if (v < board[s, e]) board[s, e] = v;
            }

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int startIndex = input[0]; int endIndex = input[1];

            bool[] visited = new bool[N + 1];
            int[] dp = new int[N + 1];
            void dijkstra(int start)
            {
                for (int index = 1; index <= N; index++)
                {
                    dp[index] = board[start, index];
                }

                visited[start] = true;

                for (int index = 1; index <= N; index++)
                {
                    int next = MinIndex();
                    visited[next] = true;
                    for (int nextIndex = 1; nextIndex <= N; nextIndex++)
                    {
                        if (visited[nextIndex]) continue;

                        if (dp[next] + board[next, nextIndex] < dp[nextIndex])
                        {
                            dp[nextIndex] = dp[next] + board[next, nextIndex];
                        }
                    }
                }
            }

            int MinIndex()
            {
                int min = INF;
                int index = 0;

                for (int i = 1; i <= N; i++)
                {
                    if (visited[i]) continue;
                    if (dp[i] < min)
                    {
                        min = dp[i];
                        index = i;
                    }
                }

                return index;
            }

            dijkstra(startIndex);
            sw.WriteLine(dp[endIndex]);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}