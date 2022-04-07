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
            int n = inputs[0];
            int r = inputs[1];

            long result = Factorial(n) / (Factorial(r) * Factorial(n - r));

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

        public static long Factorial(long N)
        {
            if (N == 0) return 1;
            else return N * Factorial(N - 1);
        }
    }
}