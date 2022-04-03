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
            long N = long.Parse(sr.ReadLine());
            long count = 1 + 4 * N + 3 * N * (N - 1) / 2;
            sw.WriteLine(count % 45678);
            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
