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

            List<(long X, long Y)> pos = new List<(long X, long Y)>();
            for (long i = 0; i < N; i++)
            {
                long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
                pos.Add((inputs[0], inputs[1]));
            }
            pos.Add((pos[0].X, pos[0].Y));

            double result = 0;
            for (int i = 0; i < N; i++)
            {
                result += pos[i].X * pos[i + 1].Y - pos[i + 1].X * pos[i].Y;
            }

            sw.WriteLine($"{Math.Round(Math.Abs(result / 2), 2):0.0}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}