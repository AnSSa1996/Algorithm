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

            List<long> lst = new List<long>();
            for (long i = 1; i < N; i++) lst.Add(i * N + i);

            sw.WriteLine(lst.Sum());

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}