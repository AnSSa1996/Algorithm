using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace BackJ
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int[] inputs = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int n = inputs[0]; int m = inputs[1];


            BigInteger total = 1;

            for (int i = n - m + 1; i <= n; i++) total *= i;
            for (int i = 1; i <= m; i++) total /= i;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}