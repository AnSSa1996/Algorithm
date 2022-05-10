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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long N = inputs[0]; long M = inputs[1];
            List<long> lst = new List<long>();
            for (long i = 0; i < M; i++) lst.Add(long.Parse(sr.ReadLine()));

            long start = 1; long end = lst.Max();

            while (start <= end)
            {
                long mid = (start + end) / 2;
                long cnt = 0;
                for (int i = 0; i < M; i++) cnt += (lst[i] + mid - 1) / mid;

                if (cnt > N) { start = mid + 1; }
                else { end = mid - 1; };
            }

            sw.WriteLine(start);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
