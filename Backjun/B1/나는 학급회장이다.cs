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
            int[] mans = new int[3];
            int[] sqr = new int[3];

            for (int i = 0; i < N; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                for (int j = 0; j < 3; j++)
                {
                    mans[j] += inputs[j];
                    sqr[j] += inputs[j] * inputs[j];
                }
            }

            int cnt = mans.Count(x => x == mans.Max());

            var lst = mans.Select((a, b) => new { score = a, index = b + 1 }).OrderByDescending(x => x.score);

            if (cnt == 1) sw.WriteLine($"{lst.First().index} {lst.First().score}");
            else
            {
                int count = 0;
                int index = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (sqr[i] == sqr.Max())
                    {
                        count++;
                        index = i + 1;
                    }
                }

                if (count == 1) sw.WriteLine($"{index} {lst.First().score}");
                else sw.WriteLine($"0 {lst.First().score}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}