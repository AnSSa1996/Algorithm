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

            List<Tuple<string, int, int, int>> lst = new List<Tuple<string, int, int, int>>();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputs = sr.ReadLine().Split();
                string name = inputs[0];
                int kor = int.Parse(inputs[1]);
                int eng = int.Parse(inputs[2]);
                int math = int.Parse(inputs[3]);

                lst.Add(new Tuple<string, int, int, int>(name, kor, eng, math));
            }

            var sortedLst = lst.OrderByDescending(x => x.Item2).ThenBy(x => x.Item3).ThenByDescending(x => x.Item4).
                ThenBy(a => a.Item1, StringComparer.Ordinal).Select(x => x.Item1);

            sw.WriteLine(string.Join("\n", sortedLst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
