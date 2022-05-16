using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            List<Tuple<long, long>> lst = new List<Tuple<long, long>>();
            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs[0]; int end = inputs[1];
                lst.Add(new Tuple<long, long>(start, end));
            }

            var sortedLst = lst.OrderBy(x => x.Item2).ThenBy(y => y.Item1).ToList();

            long e = 0;
            long cnt = 0;

            for (int i = 0; i < N; i++)
            {
                if (sortedLst[i].Item1 >= e)
                {
                    cnt++;
                    e = sortedLst[i].Item2;
                }
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
