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

            int N = int.Parse(sr.ReadLine());
            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                lst.Add(new Tuple<int, int>(inputs[0], inputs[1]));
            }

            List<int> answer = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                bool[] visited = new bool[N];
                recursive(1, 0, 0, i, N, lst, visited, answer);
            }

            sw.WriteLine(answer.Min());

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static void recursive(int S, int B, int K, int legnth, int N, List<Tuple<int, int>> lst, bool[] vistied, List<int> answer)
        {
            if (K == legnth) { answer.Add(Math.Abs(S - B)); return; }
            else
            {
                for (int i = K; i < N; i++)
                {
                    if (vistied[i] == false)
                    {
                        vistied[i] = true;
                        S *= lst[i].Item1;
                        B += lst[i].Item2;
                        recursive(S, B, K + 1, legnth, N, lst, vistied, answer);
                        vistied[i] = false;
                        S /= lst[i].Item1;
                        B -= lst[i].Item2;
                    }
                }
            }
        }
    }
}