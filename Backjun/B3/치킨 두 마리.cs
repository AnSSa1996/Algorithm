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

            long[] inputs = Array.ConvertAll(sr.ReadLine().Split(), long.Parse);
            long chicken = long.Parse(sr.ReadLine());

            long sum = inputs.Sum();
            long result = sum - (chicken * 2) >= 0 ? sum - (chicken * 2) : sum;

            sw.WriteLine(result);

            sw.Flush();
            sw.Close();
            sr.Close();
        }
    }
}
