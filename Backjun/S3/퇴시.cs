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
            List<Tuple<int, int>> dp = new List<Tuple<int, int>>();
            for (int i = 1; i <= N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int time = inputs[0];
                int cost = inputs[1];
                if (i == 1) { dp.Add(new Tuple<int, int>(time + i, cost)); continue; }

                int max = 0;
                foreach (var tuple in dp) { if (tuple.Item1 <= i) max = Math.Max(max, tuple.Item2); }
                dp.Add(new Tuple<int, int>(time + i, max + cost));
            }

            int maxNum = 0;
            var maxCost = dp.Where(x => x.Item1 <= (N + 1)).OrderByDescending(x => x.Item2);
            if (maxCost.Count() >= 1) maxNum = maxCost.First().Item2;

            sw.WriteLine(maxNum);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}