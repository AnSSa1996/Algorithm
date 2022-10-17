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
            int N = inputs[0]; int R = inputs[1]; int Q = inputs[2];

            List<List<int>> board = new List<List<int>>();
            for (int i = 0; i <= N; i++) board.Add(new List<int>());
            for (int i = 1; i < N; i++)
            {
                inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                board[inputs[0]].Add(inputs[1]);
                board[inputs[1]].Add(inputs[0]);
            }

            int[] size = new int[N + 1];

            void countSubtreeNode(int CurrentNode)
            {
                size[CurrentNode] = 1;
                foreach (int next in board[CurrentNode])
                {
                    if (size[next] != 0) continue;
                    countSubtreeNode(next);
                    size[CurrentNode] += size[next];
                }
            }

            countSubtreeNode(R);

            for (int i = 0; i < Q; i++)
            {
                sw.WriteLine(size[int.Parse(sr.ReadLine())]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
