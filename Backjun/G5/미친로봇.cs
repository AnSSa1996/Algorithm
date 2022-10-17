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
            int N = inputs[0]; int[] percentages = inputs[1..];

            int[] dx = new int[4] { 1, -1, 0, 0 };
            int[] dy = new int[4] { 0, 0, 1, -1 };


            bool[,] visited = new bool[N * 2 + 1, N * 2 + 1];

            double result = 0;
            void DFS(int y, int x, int count, double currentPercentage)
            {
                if (count == N)
                {
                    result += currentPercentage;
                    return;
                }

                for (int d = 0; d < 4; d++)
                {
                    var nextX = x + dx[d];
                    var nextY = y + dy[d];

                    if (visited[nextY, nextX]) continue;
                    visited[nextY, nextX] = true;
                    var nextPercentage = currentPercentage * (inputs[d + 1] / 100d);
                    DFS(nextY, nextX, count + 1, nextPercentage);
                    visited[nextY, nextX] = false;
                }
            }

            visited[N, N] = true;
            DFS(N, N, 0, 1);

            if (result == 1.0d) sw.WriteLine("1.0");
            else sw.WriteLine($"{result}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
