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

            double d = double.Parse(sr.ReadLine());
            double total = Math.Pow(3, 0.5) * 0.25 * d * d;

            sw.WriteLine(total);

            sw.Flush();
            sw.Close();
            sr.Close();
        }

    }
}
