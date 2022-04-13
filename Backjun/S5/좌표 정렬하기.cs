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
                lst.Add(new Tuple<int, int>(inputs[0], inputs[1]));
            }

            var sortedLst = from a in lst
                            orderby a.Item1, a.Item2
                            select a;

            foreach (var tup in sortedLst) sw.WriteLine($"{tup.Item1} {tup.Item2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
