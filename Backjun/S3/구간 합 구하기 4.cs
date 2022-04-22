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
            int T = inputs[1];

            int[] prefixSum = new int[N + 1];
            prefixSum[0] = 0;

            int[] nums = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int i = 1; i <= N; i++) prefixSum[i] = prefixSum[i - 1] + nums[i - 1];

            for (int i = 0; i < T; i++)
            {
                int[] ip = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int s = ip[0] - 1;
                int e = ip[1];
                sw.WriteLine(prefixSum[e] - prefixSum[s]);
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}