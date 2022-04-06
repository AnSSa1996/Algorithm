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
            int length = inputs[0];
            int N = inputs[1];

            List<int> baskets = Enumerable.Range(1, length).ToList();

            for (int i = 0; i < N; i++)
            {
                int[] inputs2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
                int start = inputs2[0] - 1;
                int count = inputs2[1] - inputs2[0] + 1;
                baskets.Reverse(start, count);
            }

            sw.WriteLine(string.Join(" ", baskets));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}