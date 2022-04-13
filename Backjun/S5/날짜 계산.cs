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
            int E = inputs[0];
            int S = inputs[1];
            int M = inputs[2];

            int cnt = 1;

            int A = 1;
            int B = 1;
            int C = 1;

            while (true)
            {
                if (A == E && B == S && M == C) break;

                A = A + 1 <= 15 ? A + 1 : 1;
                B = B + 1 <= 28 ? B + 1 : 1;
                C = C + 1 <= 19 ? C + 1 : 1;
                cnt++;
            }

            sw.WriteLine(cnt);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
