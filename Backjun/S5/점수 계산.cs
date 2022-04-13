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

            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();

            for (int i = 1; i <= 8; i++)
            {
                int N = int.Parse(sr.ReadLine());
                lst.Add(new Tuple<int, int>(N, i));
            }

            var sortedLst = lst.OrderByDescending(x => x.Item1).Take(5);

            sw.WriteLine(sortedLst.Sum(x => x.Item1));
            sw.WriteLine(string.Join(" ", sortedLst.Select(a => a.Item2).OrderBy(x => x)));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
