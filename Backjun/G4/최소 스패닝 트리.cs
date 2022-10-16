using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int V = inputs[0]; int E = inputs[1];
            List<(int A, int B, int C)> lines = new List<(int A, int B, int C)>();

            for (int i = 0; i < E; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lines.Add((inputs[0], inputs[1], inputs[2]));
            }

            lines.Sort((a, b) => a.C - b.C);
            int[] board = Enumerable.Range(0, V + 1).ToArray();

            int Find(int x)
            {
                if (board[x] == x) return x;
                board[x] = Find(board[x]);
                return board[x];
            }

            void Union(int a, int b)
            {
                a = Find(a);
                b = Find(b);
                if (a < b) board[b] = a;
                else board[a] = b;
            }

            long sum = 0;
            for (int i = 0; i < E; i++)
            {
                var current = lines[i];
                var A_Root = Find(current.A);
                var B_Root = Find(current.B);
                if (A_Root != B_Root)
                {
                    Union(current.A, current.B);
                    sum += current.C;
                }
            }

            sw.WriteLine(sum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}