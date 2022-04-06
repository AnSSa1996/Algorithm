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

            long N = int.Parse(sr.ReadLine());
            long[] files = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long disk = int.Parse(sr.ReadLine());

            long total = 0;
            for (int i = 0; i < N; i++) total += ((files[i] + disk - 1) / disk) * disk;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}