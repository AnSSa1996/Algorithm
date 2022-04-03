using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

            long N = long.Parse(sr.ReadLine());
            long R = (long)Math.Pow(2, N) + 1;
            sw.WriteLine(R * R);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
