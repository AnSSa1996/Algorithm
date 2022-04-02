using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int N = inputs[0];
            int M = inputs[1];
            int K = inputs[2];

            int O = Math.Min(M, K);
            int X = Math.Min(N - M, N - K);

            int result = O + X;
            sw.WriteLine(result);
            
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
