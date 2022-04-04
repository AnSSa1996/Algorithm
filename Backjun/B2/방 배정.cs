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
            int max = inputs[1];

            List<int[]> members = new List<int[]>();

            for (int i = 0; i < N; i++)
            {
                members.Add(Array.ConvertAll(sr.ReadLine().Split(), int.Parse));
            }

            var group =
                from m in members
                group m by (m[0], m[1]) into g
                select new
                {
                    Total = g.Count()
                };

            int total = group.Sum(x => (x.Total + max - 1) / max);

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
