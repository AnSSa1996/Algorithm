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
            int[] pSum = new int[N + 1];

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            for (int i = 1; i <= N; i++) { pSum[i] += pSum[i - 1] + nums[i - 1]; }

            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs[0] - 1; int end = inputs[1];
                sw.WriteLine(pSum[end] - pSum[start]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
