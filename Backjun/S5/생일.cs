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

            List<Tuple<string, int, int, int>> lst = new List<Tuple<string, int, int, int>>();

            int N = int.Parse(sr.ReadLine());

            for (int i = 0; i < N; i++)
            {
                string[] inputs = sr.ReadLine().Split();
                string name = inputs[0];
                int d = int.Parse(inputs[1]);
                int m = int.Parse(inputs[2]);
                int y = int.Parse(inputs[3]);

                lst.Add(new Tuple<string, int, int, int>(name, d, m, y));
            }

            var sortedLst = from l in lst
                            orderby l.Item4, l.Item3, l.Item2
                            select l;

            sw.WriteLine(sortedLst.Last().Item1);
            sw.WriteLine(sortedLst.First().Item1);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
