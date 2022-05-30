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

            int min = inputs[0] / 2 + inputs[1];

            sw.WriteLine(Math.Min(N, min));

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}