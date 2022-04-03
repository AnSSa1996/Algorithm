using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            double[] inputs = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);
            double min = inputs[0] / inputs[1];
            int N = int.Parse(sr.ReadLine());
            for (int i = 0; i < N; i++)
            {
                double[] nextInputs = Array.ConvertAll(sr.ReadLine().Split(), double.Parse);
                double nextCost = nextInputs[0] / nextInputs[1];
                min = Math.Min(min, nextCost);
            }
            sw.WriteLine($"{min * 1000:f2}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
