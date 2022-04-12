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

            List<Tuple<int, int>> bulks = new List<Tuple<int, int>>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                bulks.Add(new Tuple<int, int>(inputs[0], inputs[1]));
            }

            List<int> ranks = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int cnt = 1;
                int weight = bulks[i].Item1;
                int height = bulks[i].Item2;
                for (int j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    if (weight < bulks[j].Item1 && height < bulks[j].Item2) cnt++;
                }
                ranks.Add(cnt);
            }

            sw.WriteLine(string.Join(" ", ranks));
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}