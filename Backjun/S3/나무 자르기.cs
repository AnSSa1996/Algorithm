using System;
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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long TreeCount = inputs[0];
            long M = inputs[1];
            long[] trees = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long start = 0;
            long end = trees.Max();

            while (start <= end)
            {
                long mid = (start + end) / 2;
                long total = 0;
                foreach (int t in trees) if (t > mid) total += t - mid;
                if (total >= M) { start = mid + 1; }
                else { end = mid - 1; }
            }

            sw.WriteLine(end);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}