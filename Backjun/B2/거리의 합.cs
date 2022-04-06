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

            long N = long.Parse(sr.ReadLine());

            List<int> dist = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
            dist.Sort();

            long total = 0;
            for (int i = 0; i < N; i++)
            {
                total += dist[i] * (2 * i - N + 1);
            }

            sw.WriteLine(total * 2);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}