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
            int count = inputs[1];

            int[] counts = new int[count + 1];

            for (int i = 0; i < N; i++)
            {
                int num = int.Parse(sr.ReadLine());
                for (int j = num; j <= count; j += num)
                {
                    counts[j] = 1;
                }
            }

            sw.WriteLine(counts.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}