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

            int T = int.Parse(sr.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int L = inputs[0]; int N = inputs[1];

                int min = -1;
                int max = -1;

                for (int a = 0; a < N; a++)
                {
                    int pos = int.Parse(sr.ReadLine());
                    min = Math.Max(min, Math.Min(pos, L - pos));
                    max = Math.Max(max, Math.Max(pos, L - pos));
                }

                sw.WriteLine($"{min} {max}");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}