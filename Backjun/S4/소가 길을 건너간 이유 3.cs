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

            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs[0]; int time = inputs[1];
                lst.Add(new Tuple<int, int>(start, time));
            }

            var sortedLst = lst.OrderBy(x => x.Item1).ToList();

            int total = 0;
            for (int i = 0; i < N; i++)
            {
                if (total < sortedLst[i].Item1) total = sortedLst[i].Item1;
                total += sortedLst[i].Item2;
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}