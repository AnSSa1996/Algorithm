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

            int cnt = 1;
            while (true)
            {
                long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
                if (inputs.Sum() == 0) break;

                long L = inputs[0];
                long P = inputs[1];
                long V = inputs[2];
                if (P == 0) sw.WriteLine($"Case {cnt}: 0");
                else sw.WriteLine($"Case {cnt}: {V / P * L + Math.Min(V % P, L)}");
                cnt++;
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
