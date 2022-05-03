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
            BigInteger cnt = 1;

            for (int i = 2; i <= N; i++) { cnt = cnt * 2 + 1; }
            sw.WriteLine(cnt);
            if (N <= 20) { Hanoi(N, 1, 3, 2); }

            void Hanoi(int K, int start, int target, int assistant)
            {
                if (K == 1) { sw.WriteLine($"{start} {target}"); cnt++; return; }
                Hanoi(K - 1, start, assistant, target);
                sw.WriteLine($"{start} {target}");
                cnt++;
                Hanoi(K - 1, assistant, target, start);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}