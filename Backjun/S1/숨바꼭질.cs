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
            int N = inputs[0]; int M = inputs[1];
            int[] board = new int[N + 1];

            List<List<int>> road = new List<List<int>>();
            for (int i = 0; i < N + 1; i++) { road.Add(new List<int>()); }

            for (int i = 0; i < M; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int A = inputs[0]; int B = inputs[1];
                road[A].Add(B);
                road[B].Add(A);
            }

            Queue<(int current, int distance)> q = new Queue<(int current, int distance)>();
            q.Enqueue((1, 1));
            bool[] check = new bool[N + 1];
            check[1] = true;

            while (q.Count > 0)
            {
                var C = q.Dequeue();
                var current = C.current;
                var distance = C.distance;

                foreach (var next in road[current])
                {
                    if (check[next]) continue;
                    check[next] = true;
                    board[next] = distance;
                    q.Enqueue((next, distance + 1));
                }
            }

            var maxDistance = board.Max();

            sw.WriteLine($"{Array.IndexOf(board, maxDistance)} {maxDistance} {board.Count(x => x == maxDistance)}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
