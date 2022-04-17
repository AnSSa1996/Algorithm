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

            int cuts = inputs[0];
            int N = inputs[1];

            List<int> sets = new List<int>();
            List<int> singles = new List<int>();

            for (int i = 0; i < N; i++)
            {
                int[] g = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                sets.Add(g[0]);
                singles.Add(g[1]);
            }

            int set = sets.Min();
            int single = singles.Min();

            if (set > single * 6) set = single * 6;

            int total = cuts / 6 * set;
            int remain = cuts % 6;

            if (remain * single > set) total += set;
            else total += remain * single;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
