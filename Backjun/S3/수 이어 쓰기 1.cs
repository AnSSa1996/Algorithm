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
            int legnth = N.ToString().Length;

            long total = 0;
            for (int i = 0; i < (legnth - 1); i++) { total += 9 * (long)Math.Pow(10, i) * (i + 1); }
            total += (N - (long)Math.Pow(10, legnth - 1) + 1) * legnth;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}