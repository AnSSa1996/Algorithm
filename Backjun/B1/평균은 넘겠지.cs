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

            for (int i = 0; i < N; i++)
            {
                List<int> inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();
                double count = inputs[0];
                inputs.RemoveAt(0);
                double overAverage = inputs.Count(x => x > inputs.Average());
                sw.WriteLine($"{overAverage / count * 100:f3}%");
            }

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}