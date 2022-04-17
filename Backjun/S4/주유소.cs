using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            long[] distances = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long[] costs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);

            long currentCost = costs[0];
            BigInteger total = distances[0] * currentCost;
            for (int i = 1; i < N - 1; i++)
            {
                if (costs[i] < currentCost) currentCost = costs[i];
                total += currentCost * distances[i];
            }

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
