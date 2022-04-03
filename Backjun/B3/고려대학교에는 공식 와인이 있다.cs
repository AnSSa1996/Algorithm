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
            int k = inputs[1];
            int p = inputs[2];

            int sumN = N * (N + 1) / 2 * k;
            int sumN2 = N * (N + 1) * (2 * N + 1) / 6 * p;

            sw.WriteLine(sumN + sumN2);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
