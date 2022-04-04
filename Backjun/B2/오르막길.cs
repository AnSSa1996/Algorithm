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

            int N = int.Parse(sr.ReadLine());
            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int current = inputs[0];
            int max = 0;

            for (int i = 1; i < N; i++)
            {
                if (current > inputs[i] || inputs[i - 1] >= inputs[i])
                {
                    current = inputs[i];
                    continue;
                }

                max = Math.Max(max, inputs[i] - current);
            }

            sw.WriteLine(max);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
