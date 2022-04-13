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
            int N = inputs[0];
            int index = inputs[1];

            List<Tuple<int, int, int, int>> lst = new List<Tuple<int, int, int, int>>();

            for (int i = 0; i < N; i++)
            {
                int[] ip = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                int n = ip[0];
                int g = ip[1];
                int s = ip[2];
                int b = ip[3];

                lst.Add(new Tuple<int, int, int, int>(n, g, s, b));
            }

            var rank = lst.Select(a => new
            {
                Name = a.Item1,
                Rank =
                lst.Count(i => i.Item2 > a.Item2 ? true : i.Item2 < a.Item2 ? false :
                i.Item3 > a.Item3 ? true : i.Item3 < a.Item3 ? false :
                i.Item4 > a.Item4) + 1
            })
            .Where(x => x.Name == index).Select(x => x.Rank);

            sw.WriteLine(rank.First());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
