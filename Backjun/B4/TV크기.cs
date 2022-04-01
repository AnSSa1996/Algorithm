using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());


            List<int> inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse).ToList();

            int D = inputs[0];
            int H = inputs[1];
            int W = inputs[2];

            double x = ((double)D * D / (H * H + W * W));
            x = Math.Pow(x, 0.5);

            int height = (int)Math.Truncate(x * H);
            int widht = (int)Math.Truncate(x * W);

            sw.WriteLine($"{height} {widht}");

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
