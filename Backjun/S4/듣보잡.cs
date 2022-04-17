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
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StreamReader sr = new StreamReader(Console.OpenStandardInput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0];
            int M = inputs[1];

            List<string> first = new List<string>();
            List<string> second = new List<string>();

            for (int i = 0; i < N; i++) first.Add(sr.ReadLine());
            for (int i = 0; i < M; i++) second.Add(sr.ReadLine());

            var lst = first.Intersect(second).OrderBy(x => x).ToArray();

            sw.WriteLine(lst.Count());
            sw.WriteLine(string.Join("\n", lst));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
