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

            HashSet<string> hash = new HashSet<string>();
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int N = inputs[0]; int M = inputs[1];

            for (int i = 0; i < N; i++) hash.Add(sr.ReadLine());

            int cnt = 0;
            for (int i = 0; i < M; i++) if (hash.Contains(sr.ReadLine())) cnt++;

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
